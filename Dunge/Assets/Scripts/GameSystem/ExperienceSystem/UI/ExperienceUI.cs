using Scripts.GameSystem.ExperienceSystem.Handler;
using Scripts.Player;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using TMPro;
using System;

namespace Assets.Scripts.GameSystem.ExperienceSystem.UI
{
    class ExperienceUI : MonoBehaviour
    {
        [SerializeField] private PlayerExperienceHandler _playerExperienceHandler;
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private Image _currentExperienceImage;

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
            UpdateLevel();
            UpdateProgressExperience();
        }

        private void UpdateLevel()
        {
            _currentLevelText.text = _playerExperienceHandler.GetCurrentLevel().ToString();
        }

        private void UpdateProgressExperience()
        {
            _currentExperienceImage.fillAmount = (float)_playerExperienceHandler.GetCurrentExperience() /
                                                 (float)_playerExperienceHandler.GetExperienceNeedForLevelUp();
        }
    }
}
