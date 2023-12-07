using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Goodini
{
    public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public event Action<Vector2> pointerMove;

        private bool _isPointerDown;

        private Vector2 _pointerStartPosition;
        private Vector2 _pointerDragDirection;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPointerDown = true;
            _pointerStartPosition = eventData.position;
        }

        
        public void OnDrag(PointerEventData eventData)
        {
            if ( !_isPointerDown ) return;
            _pointerDragDirection = ( eventData.position - _pointerStartPosition ).normalized;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPointerDown = false;
            _pointerDragDirection = Vector2.zero;
        }

        private void Update()
        {
            if ( !_isPointerDown ) return;

            pointerMove?.Invoke(_pointerDragDirection);
        }
    }
}