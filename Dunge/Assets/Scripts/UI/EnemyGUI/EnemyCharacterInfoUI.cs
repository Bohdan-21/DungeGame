using Scripts.GameSystem.ExperienceSystem.Handler;
using UnityEngine;
using TMPro;

namespace Scripts.UI.EnemyGUI
{
    public class EnemyCharacterInfoUI : MonoBehaviour
    {
        [SerializeField] private EnemyExperienceHandler _enemyExperienceHandler;
        [SerializeField] private TextMeshProUGUI _levelText;

        private void Start()
        {
            _levelText.text = _enemyExperienceHandler.GetCurrentLevel().ToString();
        }
    }
}