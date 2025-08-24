using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Presentation.UI
{
    public class ButtonPressImageSwap : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
    {
        private Image _button; 
        public bool isPressed;

        [SerializeField] private Sprite onPressSprite;
        [SerializeField] private Sprite onUnPressSprite;

        private void Awake()
        {
            _button = GetComponent<Image>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            _button.sprite = onPressSprite;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
            _button.sprite = onUnPressSprite;
        }

        public void DebugMessage()
        {
            Debug.Log("onClick 호출");
        }
    }
}