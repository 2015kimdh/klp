using System;
using System.Linq;
using Script.Data;
using UnityEngine;

namespace Script.ServerRoll
{
    // 임의의 데이터를 반환하는 서버 역할의 객체
    [Serializable]
    public class ServerDataBase : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField] private ImageDataServerRollBundle imageDataBundle;
        [SerializeField] private ItemDataServerRollBundle itemDataBundle;
        [SerializeField] private GachaResultList gachaResultList;

        #endregion

        #region PrivateFields

        private int _gachaResultIndex = 0;

        #endregion

        public ImageDataServerRoll GetImageFromServer(string hash)
        {
            var result = imageDataBundle.bundle.Find(x => x.hash == hash);
            return result;
        }

        private ItemDataServerRoll GetItemData(string hash)
        {
            return itemDataBundle.bundle.Find(x => x.itemHash == hash);
        }

        public ItemDataServerRoll GetGachaResult()
        {
            var gachaResult = gachaResultList.resultList[_gachaResultIndex];
            _gachaResultIndex = (_gachaResultIndex + 1) % gachaResultList.resultList.Count;
            var itemResult = GetItemData(gachaResult.hash);
            return itemResult;
        }
    }
}