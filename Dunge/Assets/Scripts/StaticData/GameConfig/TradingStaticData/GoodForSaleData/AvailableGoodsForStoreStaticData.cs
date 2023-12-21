using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfig.TradingStaticData.GoodForSaleData
{
    [CreateAssetMenu(fileName = "AvailableGoodsForStore", menuName = "StaticData/TradingStaticData/GoodsForStore")]
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
