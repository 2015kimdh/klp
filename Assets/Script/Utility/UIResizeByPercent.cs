using System;
using UnityEngine;

namespace Script.Utility
{
    public class UIResizeByPercent : MonoBehaviour
    {
        private RectTransform _rect;

        [SerializeField] private RectTransform parentsRectTransform;
        [SerializeField] private UIResizeRequirement uiResizeRequirement;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            if ((int)uiResizeRequirement.direction < 2)
            {
                if (uiResizeRequirement.direction == UIStretchDirection.Top)
                {
                    Vector2 offsetMax = _rect.offsetMax;
                    offsetMax.y = -parentsRectTransform.sizeDelta.y * (uiResizeRequirement.percentage / 100f);
                    _rect.offsetMax = offsetMax;
                }
                else
                {
                    Vector2 offsetMin = _rect.offsetMin;
                    offsetMin.y = parentsRectTransform.sizeDelta.y * (uiResizeRequirement.percentage / 100f);
                    _rect.offsetMin = offsetMin;
                }
            }
            else
            {
                if (uiResizeRequirement.direction == UIStretchDirection.Right)
                {
                    Vector2 offsetMax = _rect.offsetMax;
                    offsetMax.x = -parentsRectTransform.sizeDelta.x * (uiResizeRequirement.percentage / 100f);
                    _rect.offsetMax = offsetMax;
                }
                else
                {
                    Vector2 offsetMin = _rect.offsetMin;
                    offsetMin.x = parentsRectTransform.sizeDelta.x * (uiResizeRequirement.percentage / 100f);
                    _rect.offsetMin = offsetMin;
                }
            }
        }
    }

    [Serializable]
    public class UIResizeRequirement
    {
        public UIStretchDirection direction;
        public int percentage;
    }

    public enum UIStretchDirection
    {
        Top = 0,
        Bottom = 1,
        Left = 2,
        Right = 3
    }
}