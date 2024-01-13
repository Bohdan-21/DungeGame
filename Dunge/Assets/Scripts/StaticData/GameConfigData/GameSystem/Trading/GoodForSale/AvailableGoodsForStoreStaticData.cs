using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.Trading.GoodForSale
{
    [CreateAssetMenu(fileName = "AvailableGoodsForStore", menuName = "StaticData/GameConfigData/GameSystem/Trading/GoodsForStore")]
    class AvailableGoodsForStoreStaticData : ScriptableObject
    {
        [SerializeField] private List<Goods> _goodsData;

        public IEnumerator GetEnumerator()
        {
            foreach (Goods goods in _goodsData)
                yield return goods;
        }
    }
}
