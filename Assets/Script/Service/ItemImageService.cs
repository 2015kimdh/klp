using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Script.Service
{
    public class ItemImageService : MonoBehaviour
    {
        private static string _directoryPath;
        private static string _imagePath;
        private static string Png = ".png";

        public RewardItemDataSet dateSet = new();

        public void Awake()
        {
            _directoryPath = Application.persistentDataPath + "/Image";
            _imagePath = Application.persistentDataPath + "/RewardItem";
        }

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
                _directoryPath + _imagePath + "/" + imageData.itemName + ".png",
                SpriteToTexture(imageData.itemImage).EncodeToPNG());
        }

        public void AddToDataSet(RewardImageData imageData)
        {
            dateSet.images.Add(imageData);
        }

        private bool TryGetImageFromDisk(string imageName)
        {
            if (!Directory.Exists(_directoryPath + _imagePath))
            {
                Directory.CreateDirectory(_directoryPath + _imagePath);
            }

            byte[] fileData = File.ReadAllBytes(_directoryPath + _imagePath + "/" + imageName + Png);

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