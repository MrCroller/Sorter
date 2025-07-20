using System.Collections.Generic;
using UnityEngine;

namespace Sorter
{
    public class MonoPool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> pool = new();

        private readonly T prefab;
        private readonly Transform parent;

        public MonoPool(T prefab, int initialSize, Transform parent = null)
        {
            this.prefab = prefab;
            this.parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = GameObject.Instantiate(prefab, parent);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
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
                obj = GameObject.Instantiate(prefab, parent);
            }
            return obj;
        }

        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
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
