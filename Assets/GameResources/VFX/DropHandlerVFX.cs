using Sorter.Signals;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

namespace Sorter.VFX
{
    [RequireComponent(typeof(VisualEffect))]
    public class DropHandlerVFX : MonoBehaviour
    {
        private VisualEffect visualEffect;
        private SignalBus signalBus;


        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        void Start()
        {
            visualEffect = GetComponent<VisualEffect>();
            signalBus.Subscribe<DropSignal>(OnDamageSignal);
        }

        private void OnDamageSignal(DropSignal signal)
        {
            visualEffect.SetVector2("Position", signal.view.transform.position);
            visualEffect.Play();
        }
    }
}
