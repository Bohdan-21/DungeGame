using Scripts.Enemy;
using Scripts.GameSystem.QuestSystem.Channel;
using Scripts.SaveData;
using Scripts.SaveData.Experience;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.Enemy.Experience;
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
        public event Action UpdateExperienceEvent;

        private ExperienceForKilledEnemy _experienceForKilledMonster;
        private CombatChannel _combatChannel;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService, ExperienceForKilledEnemy experienceForKilledMonster,
                               CombatChannel combatChannel)
        {
            playerProgressService.AddProgressUpdater(this);
            _experienceForKilledMonster = experienceForKilledMonster;
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

        private void KillEvet(EnemyType enemyType, int levelKilledMonster)
        {
            int experience = _experienceForKilledMonster.GetExperience(enemyType, levelKilledMonster);

            AddExperience(experience);
        }

        public void AddExperience(int experience)
        {
            int maxAddedExperience = HowMuchExperienceCanAdd(experience);

            if (experience == maxAddedExperience)
            {
                _experienceData.currentExp += experience;
                UpdateExperienceEvent?.Invoke();
            }
            else
            {
                experience -= maxAddedExperience;

                _experienceData.currentExp += maxAddedExperience;

                UpLevel();

                AddExperience(experience);
            }
        }

        public int GetCurrentLevel() =>
            _experienceData.currentLevel;

        public int GetCurrentExperience() =>
            _experienceData.currentExp;

        public int GetExperienceNeedForLevelUp() =>
            _experienceData.expNeedForLevelUp;

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
            
            LevelUpEvent?.Invoke();
        }

        public void LoadProgress(PlayerProgress playerProgress) => 
            _experienceData = new PlayerExperienceData(playerProgress.ExperienceData);

        public void UpdateProgress(PlayerProgress playerProgress) => 
            playerProgress.ExperienceData = new PlayerExperienceData(_experienceData);
    }
}