using Sorter.Figure;
using Sorter.Signals;
using UnityEngine;
using Zenject;

namespace Sorter.Draggable
{
    [RequireComponent(typeof(Collider2D))]
    internal class DropZone : MonoBehaviour
    {
        [SerializeField] FigureType type;
        private SignalBus signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void OnObjectDropped(DraggableObject obj)
        {
            FigureView view = obj.GetComponent<FigureView>();
            if (view.Type != type) return;
            signalBus.Fire(new DropSignal() { view = view });
        }
    }
}
