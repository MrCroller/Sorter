using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sorter
{
    public class MonoPool<T> : IDisposable where T : MonoBehaviour
    {
        public IReadOnlyCollection<T> ActiveItems => items;
        private readonly List<T> items = new();
        private readonly Queue<T> pool = new();
        private readonly IInstantiator instantiator;
        private readonly T prefab;
        private readonly Transform parent;

        public MonoPool(IInstantiator instantiator, T prefab, int initialSize, Transform parent = null)
        {
            this.instantiator = instantiator;
            this.prefab = prefab;
            this.parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        public void Dispose()
        {
            pool.Clear();
        }

        public T Get()
        {
            T obj;
            if (pool.Count > 0)
            {
                obj = pool.Dequeue();
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj = instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
            }
            items.Add(obj);
            return obj;
        }

        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
            items.Remove(obj);
            pool.Enqueue(obj);
        }

        public void Clear()
        {
            while (pool.Count > 0)
            {
                T obj = pool.Dequeue();
                GameObject.Destroy(obj.gameObject);
            }
        }
    }
}
