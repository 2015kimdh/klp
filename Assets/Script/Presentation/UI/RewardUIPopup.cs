using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        [Header("등급 별 색상")]
        [SerializeField] private List<Color> colors = new();

        public void SetRewardItem(RewardItemInfo info)
        {
            itemInfo = info;
            SetPopup();
        }

        public void SetImage(Sprite image)
        {
            itemImage.sprite = image;
        }

        private void SetPopup()
        {
            itemImage.sprite = imagePresenter.GetItemImage(itemInfo).itemImage;
            itemName.text = itemInfo.itemName;
            itemBrand.text = itemInfo.brandName;
            itemRarityImage.color = colors[(int)itemInfo.rarity];
            itemPrice.text = Regex.Replace(
                itemInfo.price.ToString(),
                @"\B(?=(\d{3})+(?!\d))",
                ","
            ) + "원";
        }
    }
}