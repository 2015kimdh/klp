using Script.Info;
using Script.ServerRoll;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Script.Presentation
{
    public class GetGachaResultPresenter : MonoBehaviour
    {
        #region UnityEvent

        public UnityEvent onGetResult;

        #endregion
        
        #region SerializeField

        [SerializeField] private ServerDataBase serverConnect;

        #endregion

        #region Public Fields

        public RewardItemInfo rewardItem;

        #endregion
        
        #region Method

        public void TryGacha()
        {
            rewardItem = GetGachaResult();
            rewardItem.imageName = rewardItem.itemName;
            onGetResult.Invoke();
        }
        
        /// <summary>
        /// 가챠 결과 반환
        /// </summary>
        /// <returns></returns>
        private RewardItemInfo GetGachaResult()
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