using Script.Info;
using Script.ServerRoll;
using UnityEngine;

namespace Script.Presentation
{
    public class GetGachaResultPresenter : MonoBehaviour
    {
        #region SerializeField

        [SerializeField] private ServerDataBase serverConnect;

        #endregion

        #region Method

        /// <summary>
        /// 가챠 결과 반환
        /// </summary>
        /// <returns></returns>
        public RewardItemInfo GetGachaResult()
        {
            var result = serverConnect.GetGachaResult();
            return new RewardItemInfo()
            {
                itemHash = result.itemHash,
                brandName = result.brandName,
                itemName = result.itemName,
                price = result.price,
                rarity = result.rarity
            };
        }
        
        #endregion
    }
}