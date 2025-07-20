using Sorter.Figure;
using Sorter.Signals;
using UnityEngine;
using Zenject;

namespace Sorter.Conveyor
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class EndZone : MonoBehaviour
    {
        private SignalBus signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out FigureView view))
            {
                signalBus.Fire(new EndLineSignal() { view = view });
            }
        }
    }
}
