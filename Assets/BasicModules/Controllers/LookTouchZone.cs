using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game
{
    public class LookTouchZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Header("Rect References")]
        public RectTransform containerRect;

        [Header("Settings")]
        public float magnitudeMultiplier = 1f;
        public bool invertXOutputValue;
        public bool invertYOutputValue;

        public event Action<Vector2> OnInput;

        //Stored Pointer Values
        private Vector2 previousPointerPosition;
        private Vector2 currentPointerPosition;

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, eventData.position, eventData.pressEventCamera, out previousPointerPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, eventData.position, eventData.pressEventCamera, out currentPointerPosition);

            Vector2 positionDelta = currentPointerPosition - previousPointerPosition;
            previousPointerPosition = currentPointerPosition;

            Vector2 outputPosition = ApplyInversionFilter(positionDelta);

            OnInput.Invoke(outputPosition * magnitudeMultiplier);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            previousPointerPosition = Vector2.zero;
            currentPointerPosition = Vector2.zero;

            OnInput.Invoke(Vector2.zero);
        }

        Vector2 ApplyInversionFilter(Vector2 position)
        {
            if (invertXOutputValue)
            {
                position.x = -position.x;
            }
            if (invertYOutputValue)
            {
                position.y = -position.y;
            }
            return position;
        }
    }
}
