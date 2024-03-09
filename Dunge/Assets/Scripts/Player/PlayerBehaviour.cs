using Scripts.GameSystem.ExperienceSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.StatsSystem.Handler;
using Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler;
using Scripts.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public PlayerSkillTreeHandler SkillTreeHandler;
        public PlayerExperienceHandler Experience;
        public PlayerHealth Health;
        public PlayerStatsHandler Stats;
        public PlayerDeath Death;
        public PlayerBalance Balance;
        public PlayerInventory Inventory;

        [Inject]
        private void Construct(LevelSettings levelSettings, ICameraFollow cameraFollow)
        {
            transform.position = levelSettings.PlayerSpawnPoint.position;

            cameraFollow.SetTarget(gameObject.transform);
        }
    }
}
