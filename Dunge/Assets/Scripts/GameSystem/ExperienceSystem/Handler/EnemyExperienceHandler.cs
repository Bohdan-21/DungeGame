using Scripts.SaveData;
using Scripts.SaveData.Experience;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.Enemy;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.ExperienceSystem.Handler
{
    public class EnemyExperienceHandler : MonoBehaviour
    {
        [SerializeField] private EnemyExperienceData _enemyExperienceData;


        [Inject]
        private void Construct(DeffaultSettingsForNewEnemy deffaultSettings, IPlayerProgressService playerProgressService)
        {
            _enemyExperienceData = new EnemyExperienceData(deffaultSettings, playerProgressService.PlayerProgress.LevelData.CurrentDungeLevel);
        }

        public int GetCurrentLevel() => 
            _enemyExperienceData.GetCurrentLevel();
    }
}
