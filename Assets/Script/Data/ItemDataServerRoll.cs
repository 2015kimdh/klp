using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Data
{
    [Serializable][CreateAssetMenu(fileName = "ServerRollItemData", menuName = "ItemDataServerRollBundle")]
    public class ItemDataServerRollBundle : ScriptableObject
    {
        public List<ItemDataServerRoll> bundle = new();
    }

    [Serializable]
    public class ItemDataServerRoll
    {
        /// <summary>
        /// 아이템 해쉬
        /// </summary>
        public string itemHash = "";

        /// <summary>
        /// 브랜드 이름
        /// </summary>
        public string brandName = "";
        
        /// <summary>
        /// 아이템 이름
        /// </summary>
        public string itemName = "";

        /// <summary>
        /// 아이템 가격
        /// </summary>
        public int price = 0;

        /// <summary>
        /// 아이템 희귀도 (등급)
        /// 음수로 초기화하여 미설정 시 버그 방지
        /// </summary>
        public int rarity = -1;
    }
}