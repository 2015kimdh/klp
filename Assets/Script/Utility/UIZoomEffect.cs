using UnityEngine;
using DG.Tweening;

namespace Script.Utility
{
    public class UIZoomEffect : MonoBehaviour
    {
        public RectTransform uiRoot;

        public void PlayZoomIn()
        {
            // 1.2배 확대 후 원래대로 복귀
            uiRoot.DOScale(1.2f, 0.3f).SetEase(Ease.OutQuad)
                .OnComplete(() => uiRoot.DOScale(1f, 0.2f).SetEase(Ease.InQuad));
        }
    }
}