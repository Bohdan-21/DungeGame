using UnityEngine;
using TMPro;
using Scripts.GameSystem.StatsSystem.Data;
using Scripts.GameSystem.StatsSystem.Type;

namespace Scripts.GameSystem.StatsSystem.UI
{
    public class StatCardUI : MonoBehaviour
    {
        [SerializeField] private TypeStat _typeStat;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI TypeStatText;
        [SerializeField] private TextMeshProUGUI BaseValueText;
        [SerializeField] private TextMeshProUGUI CurrentValueText;

        public void ShowStat(StatData statData)
        {
            _typeStat = statData.typeStat;

            TypeStatText.text = statData.typeStat.ToString();
            BaseValueText.text = statData.baseValue.ToString();
            CurrentValueText.text = statData.currentValue.ToString();
        }
    }
}
