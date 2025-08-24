using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Data
{
    [Serializable][CreateAssetMenu(fileName = "ServerRollGachaData", menuName = "GachaDataServerRollBundle")]
    public class GachaResultList : ScriptableObject
    {
        public List<GachaResult> resultList = new();
    }

    [Serializable]
    public class GachaResult
    {
        public Rarity rarity;
        public string hash = "";
    }
        
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Supreme
    }
}