using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Script.Presentation.UI
{
    /// <summary>
    /// TryOpenView에서 가림막을 열기 위한 코드
    /// </summary>
    public class WindowOpen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Header("설정")] public float returnDuration = 0.3f;

        #region Serialize Fields

        [SerializeField] private RectTransform window;

        #endregion

        #region UnityEvent

        public UnityEvent onDraggedUp;

        #endregion

        #region Private Fields

        private Vector2 _startPos;
        private Vector2 _startUIPos;
        private bool _isDrag = false;
        [SerializeField]
        private float _triggerDistance;

        #endregion

        private void Start()
        {
            Canvas.ForceUpdateCanvases();
            _startUIPos = window.anchoredPosition;
            _triggerDistance = window.rect.height / 2f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDrag) return;

            Vector2 delta = eventData.position - _startPos;

            // 이동할 새 위치 계산
            float newY = window.anchoredPosition.y + delta.y;

            // 위/아래 제한 적용
            float maxY = _startUIPos.y + window.rect.height; // 위 제한
            float minY = _startUIPos.y; // 아래 제한
            newY = Mathf.Clamp(newY, minY, maxY);

            window.anchoredPosition = new Vector2(window.anchoredPosition.x, newY);

            _startPos = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDrag = false;

            float draggedDistance = window.anchoredPosition.y - _startUIPos.y;

            if (draggedDistance >= _triggerDistance)
            {
                onDraggedUp.Invoke();
                window.anchoredPosition = new Vector2(window.anchoredPosition.x, _startUIPos.y + window.rect.height);
            }
            else
            {
                // 원위치로 부드럽게 돌아가기
                StartCoroutine(ResetUI());
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPos = eventData.position;
            _isDrag = true;
        }

        public void ResetUIInstant()
        {
            window.anchoredPosition = _startUIPos;
        }

        private IEnumerator ResetUI()
        {
            Vector2 currentPos = window.anchoredPosition;
            float elapsed = 0f;

            while (elapsed < returnDuration)
            {
                window.anchoredPosition = Vector2.Lerp(currentPos, _startUIPos, elapsed / returnDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            window.anchoredPosition = _startUIPos;
        }
    }
}