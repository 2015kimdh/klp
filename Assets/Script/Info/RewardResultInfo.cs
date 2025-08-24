using System;

namespace Script.Info
{
    /// <summary>
    /// 가챠 이력 보여주기용
    /// 혹은 인벤토리에서 정렬할 때 쓸 용도
    /// </summary>
    [Serializable]
    public class RewardResultInfo
    {
        /// <summary>
        /// 상품 받은 시간
        /// </summary>
        public DateTime rewardTime;
        /// <summary>
        /// 상품 해시코드
        /// </summary>
        public string itemHash = "";
    }
}