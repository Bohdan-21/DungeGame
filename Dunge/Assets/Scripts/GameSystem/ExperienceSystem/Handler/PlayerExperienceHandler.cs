using Scripts.SaveData;
using Scripts.SaveData.Experience;
using Scripts.Services.PlayerProgressService;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.ExperienceSystem.Handler
{
    public class PlayerExperienceHandler : MonoBehaviour, IPlayerProgressLoader
    {
        [SerializeField] private ExperienceData _experienceData;

        public static PlayerExperienceHandler Instance;

        public event Action PlayerLevelUpEvent;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService)
        {
            playerProgressService.AddProgressUpdater(this);
        }

        private void Awake()
        {
            Instance = this;
        }

        public void AddExperience(int experience)
        {
            int maxAddedExperience = HowMuchExperienceCanAdd(experience);

            if (experience == maxAddedExperience)
                _experienceData.currentExp += experience;
            else
            {
                experience -= maxAddedExperience;

                _experienceData.currentExp += maxAddedExperience;

                UpLevel();

                AddExperience(experience);
            }
        }

        private int HowMuchExperienceCanAdd(int experience)
        {
            if (_experienceData.currentExp + experience >= _experienceData.expNeedForLevelUp)
            {
                return _experienceData.expNeedForLevelUp - _experienceData.currentExp;
            }
            else
                return experience;
        }

        private void UpLevel()
        {
            _experienceData.currentLevel++;
            _experienceData.currentExp = 0;
            _experienceData.expNeedForLevelUp = (int)(_experienceData.expNeedForLevelUp * _experienceData.numberForMultiplyForUpdateExpNeedForLevelUp);
            Debug.Log("Level up");
            PlayerLevelUpEvent?.Invoke();
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _experienceData = new ExperienceData(playerProgress.ExperienceData);
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.ExperienceData = new ExperienceData(_experienceData);
        }
    }
}
