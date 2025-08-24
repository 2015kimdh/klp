using Script.Presentation.UI;
using UnityEngine;

namespace Script.Presentation.Manager
{
    public class PopupManager : MonoBehaviour
    {
        #region Serialize Field

        [SerializeField] private GetImagePresenter imagePresenter;
        [SerializeField] private GetGachaResultPresenter gachaResultPresenter;
        [SerializeField] private RewardUIPopup popUp;
        
        #endregion

        #region Methods

        private void Start()
        {
            gachaResultPresenter.onGetResult.AddListener(SetPopup);
        }
        
        private void SetPopup()
        {
            popUp.SetRewardItem(gachaResultPresenter.rewardItem);
            popUp.SetImage(imagePresenter.GetItemImage(gachaResultPresenter.rewardItem).itemImage);
        }

        #endregion
    }
}