using System.IO;
using System.Linq;
using Script.Service.BaseClass;
using UnityEngine;

namespace Script.Service
{
    public class ItemImageService : BaseService
    {
        public static readonly string DirectoryPath = Application.persistentDataPath + "/Image";
        public static readonly string ImagePath = Application.persistentDataPath + "/RewardItem";
        public static readonly string Png = ".png";

        public RewardItemDataSet dateSet = new();

        public RewardImageData GetImage(string imageName)
        {
            if (CheckImageOnService(imageName))
                return dateSet.images.First(x => x.itemName == imageName);
            else
                return null;
        }
        
        public bool CheckImageOnService(string imageName)
        {
            var result = dateSet.images.Select(x => x.itemName == imageName);
            if (!result.Any())
                return TryGetImageFromDisk(imageName);
            else
                return true;
        }

        /// <summary>
        /// 새 이미지를 받았을 때 로컬에 저장하기
        /// </summary>
        /// <param name="imageData"></param>
        public void SaveImageToDisk(RewardImageData imageData)
        {
            File.WriteAllBytes(
                DirectoryPath + ImagePath + "/" + imageData.itemName + ".png",
                SpriteToTexture(imageData.itemImage).EncodeToPNG());
        }

        public void AddToDataSet(RewardImageData imageData)
        {
            dateSet.images.Add(imageData);
        }
        
        private bool TryGetImageFromDisk(string imageName)
        {
            if (!Directory.Exists(DirectoryPath + ImagePath))
            {
                Directory.CreateDirectory(DirectoryPath + ImagePath);
            }

            byte[] fileData = File.ReadAllBytes(DirectoryPath + ImagePath + "/" + imageName + Png);

            Texture2D tex = new Texture2D(0, 0);
            var result = tex.LoadImage(fileData);
            if (!result)
                return false;

            Rect rect = new Rect(0, 0, tex.width, tex.height);
            var sprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f));

            RewardImageData newData = new RewardImageData()
            {
                itemImage = sprite,
                itemName = imageName
            };
            dateSet.images.Add(newData);
            return true;
        }

        private Texture2D SpriteToTexture(Sprite sprite)
        {
            if (sprite.rect.width != sprite.texture.width)
            {
                Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
                Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                    (int)sprite.textureRect.y,
                    (int)sprite.textureRect.width,
                    (int)sprite.textureRect.height);
                newText.SetPixels(newColors);
                newText.Apply();
                return newText;
            }
            else
                return sprite.texture;
        }
    }
}