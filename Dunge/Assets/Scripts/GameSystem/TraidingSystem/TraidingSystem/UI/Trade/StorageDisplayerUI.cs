using Scripts.GameMechanic.ItemSystem;
using Scripts.SaveData.PlayerData.Storage;
using Scripts.StaticData.GameConfigData.GameSystem.Trading.Price;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade
{
    public class StorageDisplayerUI : MonoBehaviour
    {
        [SerializeField] private PriceStaticData _priceData;

        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private Transform Content;

        private List<GameObject> _spawnedCards = new List<GameObject>();
        private Action<TypeItem> _whenUserSelectCardCallback;

        public void SetCallback(Action<TypeItem> whenUserSelectCardCallback) => 
            _whenUserSelectCardCallback = whenUserSelectCardCallback;

        public void SpawnStorageElement(StorageHandler storage)
        {
            GameObject card;
            int price;

            foreach (ItemCount item in storage)
            {
                card = Instantiate(_cardPrefab, Content);
                price = _priceData.GetItemPrice(item.GetItemType());

                card.GetComponent<ItemCard>().Initialize(item, price, UserSelectCard);

                _spawnedCards.Add(card);
            }
        }

        public void ClearAll()
        {
            foreach (GameObject card in _spawnedCards)
                Destroy(card);

            _spawnedCards.Clear();
        }

        private void UserSelectCard(TypeItem typeItem) =>
            _whenUserSelectCardCallback?.Invoke(typeItem);
    }
}