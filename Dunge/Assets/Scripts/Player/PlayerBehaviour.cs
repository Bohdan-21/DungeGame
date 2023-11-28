using Scripts.GameSystem.ExperienceSystem.Player;
using Scripts.GameSystem.SkillTreeSystem.Logic;
using Scripts.GameSystem.StatsSystem.Logic;
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
        public SkillTreeHandler SkillTreeHandler;
        public PlayerExperience Experience;
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
