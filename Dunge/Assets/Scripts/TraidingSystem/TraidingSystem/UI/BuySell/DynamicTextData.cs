using Scripts.SaveData.Storage;
using UnityEngine;
using TMPro;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.TradingStaticData.PriceData;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.BuySell
{
    public class DynamicTextData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemCountSelectedText;
        [SerializeField] private TextMeshProUGUI _allPriceTextForBuyer;
        [SerializeField] private TextMeshProUGUI _allPriceTextForSalesman;

        [SerializeField] private PriceStaticData _priceData;

        public void Show(int countSelectedItem, ItemType itemType, MerchantType merchantType)
        {
            int totalPrice = _priceData.GetItemPrice(itemType) * countSelectedItem;

            _itemCountSelectedText.text = countSelectedItem.ToString();

            if (merchantType == MerchantType.Buyer)
            {
                _allPriceTextForBuyer.text = "+" + totalPrice.ToString();
                _allPriceTextForSalesman.text = "-" + totalPrice.ToString();
            }
            else
            {
                _allPriceTextForBuyer.text = "-" + totalPrice.ToString();
                _allPriceTextForSalesman.text = "+" + totalPrice.ToString();
            }

            if (totalPrice == 0)
            {
                _allPriceTextForBuyer.text = totalPrice.ToString();
                _allPriceTextForSalesman.text = totalPrice.ToString();
            }
        }
    }
}