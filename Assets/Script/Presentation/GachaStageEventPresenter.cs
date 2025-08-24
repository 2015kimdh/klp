using Script.Presentation.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Presentation
{
    public class GachaStageEventPresenter : MonoBehaviour
    {
        #region Property

        private GachaStageStatus StageStatus
        {
            set
            {
                if (_status != value)
                {
                    _status = value;
                    gachaStageStatusEvent.Invoke(_status);
                }
            }
        }

        public GachaStageStatus CurrentStatus => _status;

        #endregion
        
        #region Private Field

        private GachaStageStatus _status = GachaStageStatus.Init;

        #endregion

        #region Pulbic Field

        public UnityEvent<GachaStageStatus> gachaStageStatusEvent;

        #endregion

        public void ChangeStatus(GachaStageStatus targetStatus)
        {
            StageStatus = targetStatus;
        }
    }
}