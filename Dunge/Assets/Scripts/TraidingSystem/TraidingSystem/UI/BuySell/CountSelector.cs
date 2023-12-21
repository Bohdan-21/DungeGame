using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.BuySell
{
    public class CountSelector : MonoBehaviour
    {
        [SerializeField] private Slider _countSelector;

        public event Action ChangeCountSelectedEvent;

        public int CurrentCountSelected { get; private set; }

        public void ConfigurateCountSelector(int minValue, int maxValue)
        {
            _countSelector.minValue = _countSelector.value = CurrentCountSelected = minValue;
            _countSelector.maxValue = maxValue;
        }

        public void UpdateCount()
        {
            CurrentCountSelected = (int)_countSelector.value;
            
            ChangeCountSelectedEvent?.Invoke();
        }
    }
}