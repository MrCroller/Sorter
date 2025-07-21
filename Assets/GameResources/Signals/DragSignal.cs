using Sorter.Figure;
using UnityEngine;

namespace Sorter.Signals
{
    public class DragSignal : IClearSignal
    {
        public FigureView view;
        public bool isDragged;

        public Transform Transform => view.transform;
    }
}
