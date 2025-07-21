using UnityEngine;

namespace Sorter.Belt
{
    public interface IBeltView
    {
        Vector2 StartPosX { get; }
        Vector2 EndPosX { get; }
    }
}