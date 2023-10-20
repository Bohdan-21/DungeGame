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
        public PlayerInventory Inventory;
        public PlayerHealth Health;
        public PlayerDeath Death;

        [Inject]
        private void Construct(LevelSettings levelSettings)
        {
            transform.position = levelSettings.PlayerSpawnPoint.position;
        }
    }
}
