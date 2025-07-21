using Sorter.Draggable;
using UnityEngine;

namespace Sorter.Belt
{
    public interface IItemOnBelt
    {
        float ProgressInterop { get; set; }
        float Speed { get; }
        IDragggable Draggable { get; }
        Vector2 Position { get; }

        void ClearItem();
        void Init(Vector2 startPosition, Vector2 endPosition, float speed);
    }
}