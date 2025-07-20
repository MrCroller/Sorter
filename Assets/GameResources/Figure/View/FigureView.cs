using System;
using UnityEngine;
using Zenject;

namespace Sorter.Figure
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FigureView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public FigureType Type { get; private set; }
        public float Speed { get; private set; }
        public bool IsDragging { get; private set; }


        private void OnValidate()
        {
            spriteRenderer = spriteRenderer != null ? spriteRenderer : GetComponent<SpriteRenderer>();
        }

        public void Construct(FigureType type, float speed, Sprite figure)
        {
            Type = type;
            Speed = speed;
            spriteRenderer.sprite = figure;
        }

        public void Dispose()
        {
            spriteRenderer.SetAlpha(.5f);
        }
    }
}
