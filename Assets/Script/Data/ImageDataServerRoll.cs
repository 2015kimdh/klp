using System.Collections.Generic;
using UnityEngine;

namespace Script.Data
{
    [CreateAssetMenu(fileName = "ServerRollImageData", menuName = "ImageDataServerRollBundle")]
    public class ImageDataServerRollBundle : ScriptableObject
    {
        public List<ImageDataServerRoll> bundle = new();
    }

    public class ImageDataServerRoll
    {
        public string hash = "";
        public Sprite image;
    }
}