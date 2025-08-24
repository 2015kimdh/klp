using System;
using Script.Presentation.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Presentation
{
    /// <summary>
    /// 가챠 뷰 상태가 바뀔 때 이벤트 호출.
    /// 상태 별로 반응하도록 해서 작성
    /// </summary>
    public class GachaStatusChangeEventInvoker : MonoBehaviour
    {
        #region SerializeField

        /// <summary>
        /// 반응할 상태
        /// </summary>
        [SerializeField] private GachaStageStatus targetStatus;

        [SerializeField] private GachaStageEventPresenter presenter;

        #endregion

        #region Private Field

        /// <summary>
        /// 상태가 바뀌었을 때 내 상태였는지 플래그.
        /// 내 상태였다면 Exit을 호출해야하기 때문
        /// </summary>
        private bool _wasMyStatus = false;

        #endregion

        #region Event

        public UnityEvent onEnter;
        public UnityEvent onExit;

        #endregion

        #region Methods

        private void Awake()
        {
            presenter.gachaStageStatusEvent.AddListener(ObserveStatus);
        }

        private void ObserveStatus(GachaStageStatus status)
        {
            if (status == targetStatus)
            {
                _wasMyStatus = true;
                onEnter.Invoke();
            }
            else
            {
                if (_wasMyStatus == true)
                {
                    onExit.Invoke();
                }

                _wasMyStatus = false;
            }
        }

        #endregion
    }
}