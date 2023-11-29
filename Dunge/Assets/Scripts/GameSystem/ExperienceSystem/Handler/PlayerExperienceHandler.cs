using Scripts.Enemy;
using Scripts.GameSystem.QuestSystem.Channel;
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
        [SerializeField] private PlayerExperienceData _experienceData;

        public static PlayerExperienceHandler Instance;

        public event Action LevelUpEvent;

        private CombatChannel _combatChannel;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService, CombatChannel combatChannel)
        {
            playerProgressService.AddProgressUpdater(this);
            _combatChannel = combatChannel;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start() =>
            _combatChannel.KillEvent += KillEvet;

        private void OnDestroy() =>
            _combatChannel.KillEvent -= KillEvet;

        private void KillEvet(EnemyType enemyType)
        {
            AddExperience(50);
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
            LevelUpEvent?.Invoke();
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _experienceData = new PlayerExperienceData(playerProgress.ExperienceData);
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.ExperienceData = new PlayerExperienceData(_experienceData);
        }
    }
}
