using System;
using DG.Tweening;
using UnityEngine;

namespace Script.Presentation.UI
{
    public class PendulumShakingAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform clawRectTransform;

        [SerializeField] private float angle = 15f;
        [SerializeField] private float duration = 1.5f;

        private Tween _shakingTween;

        private void Start()
        {
            clawRectTransform.localRotation = Quaternion.Euler(0, 0, -angle);

            // 좌우 흔들림
            _shakingTween = clawRectTransform.DOLocalRotate(new Vector3(0, 0, angle), duration)
                .SetEase(Ease.InOutSine) // 자연스럽게
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void StartShaking()
        {
            if (_shakingTween != null)
                _shakingTween.Kill();

            // 좌우 흔들림
            _shakingTween = clawRectTransform.DOLocalRotate(new Vector3(0, 0, angle), duration)
                .SetEase(Ease.InOutSine) // 자연스럽게
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void StopShaking()
        {
            clawRectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            _shakingTween.Kill();
        }
    }
}