using Sorter.Draggable;
using Sorter.Signals;
using UnityEngine;
using Zenject;

namespace Sorter.Belt
{
    public class ItemOnBelt : MonoBehaviour, IItemOnBelt
    {
        public const float MAX = 1f;
        public float Speed { get; private set; }
        public IDragggable Draggable => draggable;
        private DraggableObject draggable;
        public float ProgressInterop
        {
            get => progressInterop;
            set
            {
                var clampValue = Mathf.Clamp01(value);

                var newPos = Vector3.Lerp(startPos, endPos, clampValue);
                transform.position = newPos;
                progressInterop = clampValue;
            }
        }

        public Vector2 Position => transform.position;

        private Vector3 startPos;
        private Vector3 endPos;
        private float progressInterop;
        private SignalBus signalBus;


        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        private void Awake()
        {
            TryGetComponent(out draggable);
        }

        public void Init(Vector2 startPosition, Vector2 endPosition, float speed)
        {
            startPos = startPosition;
            endPos = endPosition;
            Speed = speed;
        }

        public void ClearItem()
        {
            signalBus.Fire(new ClearSignal() { Transform = transform });
        }
    }
}
