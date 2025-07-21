using System;
using System.Collections;
using System.Linq;
using Sorter.Belt;
using Sorter.Figure;
using Sorter.Signals;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Sorter.Draggable
{
    public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDragggable
    {
        public bool IsDragging => isDragging;

        private Setting setting;
        private SignalBus signalBus;
        private Vector3 startDragPosition;
        private Camera mainCamera;
        private bool isDragging;


        [Inject]
        public void Construct(Setting setting, SignalBus signalBus)
        {
            this.setting = setting;
            this.signalBus = signalBus;
        }

        private void Awake() => mainCamera = Camera.main;

        public void SetStartPosition() => startDragPosition = transform.position;

        public void OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            SetStartPosition();
            //signalBus.Fire(new DragSignal() { isDragged = isDragging, view = figureView });
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 screenPos = eventData.position;
            screenPos.z = 10f;
            transform.position = mainCamera.ScreenToWorldPoint(screenPos);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;

            if (TryGetDropZone(out DropZone zone))
            {
                if (!zone.OnObjectDropped(this)) ReturnToStart();
            }
            else
            {
                ReturnToStart();
            }
        }

        private bool TryGetDropZone(out DropZone zone)
        {
            zone = null;
            Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
            Debug.Log("posChek: " + transform.position);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out zone)) return true;
            }
            return false;
        }

        private void ReturnToStart()
        {
            StartCoroutine(SmoothReturn());
        }

        private IEnumerator SmoothReturn()
        {
            Vector3 from = transform.position;
            Vector3 to = startDragPosition;
            float elapsed = 0f;

            while (elapsed < setting.ReturnDuration)
            {
                transform.position = Vector3.Lerp(from, to, elapsed / setting.ReturnDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = to;
            signalBus.Fire(new DragSignal() { isDragged = isDragging, view = GetComponent<FigureView>() });
        }

        [Serializable]
        public class Setting
        {
            [field: SerializeField] public float ReturnDuration { get; private set; }
        }
    }
}