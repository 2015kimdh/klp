using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Data
{
    [Serializable][CreateAssetMenu(fileName = "ServerRollImageData", menuName = "ImageDataServerRollBundle")]
    public class ImageDataServerRollBundle : ScriptableObject
    {
        public List<ImageDataServerRoll> bundle = new();
    }

    [Serializable]
    public class ImageDataServerRoll
    {
        public string hash = "";
        public Sprite image;
    }
}