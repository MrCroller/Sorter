using Sorter.Figure;
using UnityEngine;

namespace Sorter.Signals
{
    public class ClearSignal : IClearSignal
    {
        public Transform Transform { get; set; }
        public FigureView View
        {
            get
            {
                if (view == null)
                    Transform.TryGetComponent<FigureView>(out view);
                return view;
            }
        }
        private FigureView view;
    }
}
