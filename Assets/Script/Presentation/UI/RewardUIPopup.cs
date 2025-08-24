using Script.Info;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Presentation.UI
{
    public class RewardUIPopup : MonoBehaviour
    {
        [SerializeField] private RewardItemInfo itemInfo;

        [SerializeField] private GetImagePresenter imagePresenter;
        
        [SerializeField] private Image itemImage;
        [SerializeField] private Image itemRarityImage;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemBrand;
        [SerializeField] private TMP_Text itemPrice;
        
        public void SetRewardItem(RewardItemInfo info)
        {
            itemInfo = info;
        }

        private void SetPopup()
        {
            itemImage.sprite = imagePresenter.GetItemImage(itemInfo).itemImage;
            itemName.text = itemInfo.itemName;
            itemBrand.text = itemInfo.brandName;
            itemPrice.text = itemInfo.price.ToString();
        }
    }
}