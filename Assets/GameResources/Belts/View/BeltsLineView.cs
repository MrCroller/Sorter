using UnityEngine;

namespace Sorter.Belt
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class BeltsLineView : MonoBehaviour, IBeltView
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [field: SerializeField] public Vector2 Size { get; private set; } = new(3f, .5f);

        public Vector2 StartPosX
        {
            get
            {
                var st =  (Vector2)transform.position - (Size / 2);
                return new Vector2(st.x, transform.position.y);
            }
        }

        public Vector2 EndPosX
        {
            get
            {
                var end = (Vector2)transform.position + (Size / 2);
                return new Vector2 (end.x, transform.position.y);
            }
        }

        private void OnValidate()
        {
            spriteRenderer = spriteRenderer == null ? GetComponent<SpriteRenderer>() : spriteRenderer;

            spriteRenderer.size = Size;
        }
    }
}
