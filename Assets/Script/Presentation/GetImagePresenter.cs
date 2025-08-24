using System;
using Script.Info;
using Script.ServerRoll;
using Script.Service;
using UnityEngine;

namespace Script.Presentation
{
    [Serializable]
    public class GetImagePresenter : MonoBehaviour
    {
        #region SerializeField

        [SerializeField] private ServerDataBase serverConnect;

        #endregion
        
        #region Private Field

        private ItemImageService _imageService;

        #endregion

        private void Awake()
        {
            _imageService = new ItemImageService();
        }

        public RewardItemImageInfo GetItemImage(RewardItemInfo item)
        {
            if (_imageService.CheckImageOnService(item.imageName))
            {
                RewardImageData data = _imageService.GetImage(item.imageName);
                return new RewardItemImageInfo()
                {
                    imageName = data.itemName,
                    itemImage = data.itemImage
                };
            }
            else
            {
                var result = serverConnect.GetImageFromServer(item.itemHash);

                RewardImageData data = new()
                {
                    itemImage = result.image,
                    itemName = result.image.name
                };
                _imageService.AddToDataSet(data);
                _imageService.SaveImageToDisk(data);
                
                return new RewardItemImageInfo()
                {
                    imageName = data.itemName,
                    itemImage = data.itemImage
                };
            }
        }
    }
}