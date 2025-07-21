using System;
using Sorter.Belt;
using UnityEngine;

namespace Sorter.Figure
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FigureView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public FigureType Type { get; private set; }
        public bool IsDragging { get; private set; }

        public IItemOnBelt ItemBelt => itemBelt;
        private ItemOnBelt itemBelt;


        private void OnValidate()
        {
            spriteRenderer = spriteRenderer != null ? spriteRenderer : GetComponent<SpriteRenderer>();
        }

        private void Awake()
        {
            TryGetComponent(out itemBelt);
        }

        public void Construct(FigureType type, Sprite figure)
        {
            Type = type;
            spriteRenderer.sprite = figure;
        }

        public void Dispose()
        {
            spriteRenderer.SetAlpha(.5f);
        }
    }
}
