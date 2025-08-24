using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Script.Service
{
    public class ItemImageService : MonoBehaviour
    {
        private static string _imagePath;
        private static string Png = ".png";

        public RewardItemDataSet dateSet = new();

        public void Awake()
        {
            _imagePath = Application.persistentDataPath + "/RewardItem";
        }

        public RewardImageData GetImage(string imageName)
        {
            if (CheckImageOnService(imageName))
                return dateSet.images.Find(x => x.itemName == imageName);
            else
                return null;
        }

        public bool CheckImageOnService(string imageName)
        {
            var result = dateSet.images.FindAll(x => x.itemName == imageName);
            if (result.Count == 0)
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
                _imagePath + "/" + imageData.itemName + ".png",
                SpriteToTexture(imageData.itemImage).EncodeToPNG());
        }

        public void AddToDataSet(RewardImageData imageData)
        {
            dateSet.images.Add(imageData);
        }

        private bool TryGetImageFromDisk(string imageName)
        {
            if (!Directory.Exists(_imagePath))
            {
                Directory.CreateDirectory(_imagePath);
            }

            if (!File.Exists(_imagePath + "/" + imageName + Png))
                return false;

            byte[] fileData = File.ReadAllBytes(_imagePath + "/" + imageName + Png);

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
            // if (sprite.rect.width != sprite.texture.width)
            // {
            //     Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            //     Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
            //         (int)sprite.textureRect.y,
            //         (int)sprite.textureRect.width,
            //         (int)sprite.textureRect.height);
            //     newText.SetPixels(newColors);
            //     newText.Apply();
            //
            //     RenderTexture curRenderTexture = RenderTexture.active;
            //     RenderTexture copiedRenderTexture = new RenderTexture(newText.width, newText.height, 0);
            //     Graphics.Blit(newText, copiedRenderTexture);
            //     RenderTexture.active = copiedRenderTexture;
            //
            //     Texture2D convertedImage = new Texture2D(newText.width, newText.height, TextureFormat.RGBA32, false);
            //     convertedImage.ReadPixels(new Rect(0, 0, newText.width, newText.height), 0, 0);
            //     convertedImage.Apply();
            //     RenderTexture.active = curRenderTexture;
            //
            //     return convertedImage;
            // }
            // else
                return ConvertToReadable(sprite.texture);
        }
        
        private Texture2D ConvertToReadable(Texture2D texture)
        {
            // RenderTexture로 복사
            RenderTexture rt = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            Graphics.Blit(texture, rt);

            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = rt;

            // RGBA32 포맷으로 새 Texture2D 생성
            Texture2D readableTex = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
            readableTex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            readableTex.Apply();

            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(rt);

            return readableTex;
        }
    }
}