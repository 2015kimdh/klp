using Script.Presentation.Enum;
using UnityEngine;

namespace Script.Presentation.UI
{
    public class ChangeGachaStatusMethodProvider : MonoBehaviour
    {
        [SerializeField] private GachaStageStatus targetStatus;
        private GachaStageEventPresenter _presenter;

        private void Start()
        {
            _presenter = FindAnyObjectByType<GachaStageEventPresenter>();
        }

        public void ChangeStatus()
        {
            _presenter.ChangeStatus(targetStatus);
        }
    }
}