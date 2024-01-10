using Scripts.GameSystem.ExperienceSystem.Handler;
using Scripts.Player;
using UnityEngine;
using Zenject;
using TMPro;

namespace Assets.Scripts.GameSystem.ExperienceSystem.UI
{
    class PlayerExperienceTextUI : MonoBehaviour
    {
        [SerializeField] private PlayerExperienceHandler _playerExperienceHandler;

        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private TextMeshProUGUI _currentExperienceText;
        [SerializeField] private TextMeshProUGUI _experienceNeedForLevelUpText;

        [Inject]
        private void Construct(PlayerBehaviour playerBehaviour) => 
            _playerExperienceHandler = playerBehaviour.Experience;

        private void Start()
        {
            _playerExperienceHandler.UpdateExperienceEvent += UpdateExperience;
            UpdateExperience();
        }

        private void OnDestroy() => 
            _playerExperienceHandler.UpdateExperienceEvent -= UpdateExperience;

        private void UpdateExperience()
        {
            _currentLevelText.text = _playerExperienceHandler.GetCurrentLevel().ToString();
            _currentExperienceText.text = _playerExperienceHandler.GetCurrentExperience().ToString();
            _experienceNeedForLevelUpText.text = _playerExperienceHandler.GetExperienceNeedForLevelUp().ToString();
        }
    }
}
