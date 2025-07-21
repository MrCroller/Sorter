using Sorter.Figure;
using UnityEngine;

namespace Sorter.Signals
{
    public class DropSignal : IClearSignal
    {
        public FigureView view;

        public Transform Transform => view.transform;
    }
}
