using Scripts.GameSystem.ExperienceSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.StatsSystem.Handler;
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
    class PlayerBehaviour : MonoBehaviour
    {
        public PlayerSkillTreeHandler SkillTreeHandler;
        public PlayerExperienceHandler Experience;
        public PlayerInventory Inventory;
        public PlayerHealth Health;
        public PlayerStatsHandler Stats;
        public PlayerDeath Death;

        [Inject]
        private void Construct(LevelSettings levelSettings)
        {
            transform.position = levelSettings.PlayerSpawnPoint.position;
        }
    }
}
