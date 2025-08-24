using System;
using Script.Service;
using UnityEngine;

namespace Script.Presentation
{
    [Serializable]
    public class GetImagePresenter : MonoBehaviour
    {
        #region Private Field

        private ItemImageService _imageService;

        #endregion

        private void Awake()
        {
            _imageService = new ItemImageService();
        }
    }
}