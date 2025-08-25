using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Presentation.UI
{
    public class UILine : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField] private RectTransform start;

        [SerializeField] private RectTransform target;

        [SerializeField] private Image lineImage;

        #endregion
        
        RectTransform _lineRect;
        RectTransform _parentRect;


        private void Awake()
        {
            _lineRect = lineImage.rectTransform;
            _parentRect = _lineRect.parent as RectTransform;
        }

        void LateUpdate()
        {
            Vector2 aLocal = WorldToParentLocal(start.position);
            Vector2 bLocal = WorldToParentLocal(target.position);

            Vector2 center = (aLocal + bLocal) * 0.5f;
            _lineRect.anchoredPosition = center;

            Vector2 delta = bLocal - aLocal;
            float length = delta.magnitude;
            float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

            // 사이즈/회전 적용 (가로 길이 = length, 세로 = thickness)
            _lineRect.sizeDelta = new Vector2(length, _lineRect.sizeDelta.y);
            _lineRect.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
        
        private Vector2 WorldToParentLocal(Vector3 worldPos)
        {
            Vector2 screen = RectTransformUtility.WorldToScreenPoint(null, worldPos);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRect, screen, null, out var local);
            return local;
        }
    }
}