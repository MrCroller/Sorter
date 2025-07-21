using Sorter.Signals;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

namespace Sorter.VFX
{
    [RequireComponent(typeof(VisualEffect))]
    public class DamageHandlerVFX : MonoBehaviour
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
            signalBus.Subscribe<EndOfBeltSignal>(OnDamageSignal);
        }

        private void OnDamageSignal(EndOfBeltSignal signal)
        {
            visualEffect.SetVector2("Position", signal.Position);
            visualEffect.Play();
        }
    }
}
