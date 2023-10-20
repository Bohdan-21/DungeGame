using Scripts.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Enemy
{
    class CheckAttackRange : MonoBehaviour
    {
        private const string LayerNameForPlayer = "Player";

        public EnemyAttack Attack;
        public EnemyDeath EnemyDeath;
        public TriggerObserver Observer;

        private bool _isEnemyDie;

        private void Start()
        {
            _isEnemyDie = false;
            Attack.enabled = false;

            Observer.TriggerEnter += TriggerEnter;
            Observer.TriggerExit += TriggerExit;

            EnemyDeath.EnemyDie += EnemyDie;
        }

        private void EnemyDie()
        {
            _isEnemyDie = true;
            Attack.enabled = false;
        }

        private void TriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(LayerNameForPlayer) && !_isEnemyDie)
                Attack.enabled = true;
        }

        private void TriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(LayerNameForPlayer) && !_isEnemyDie)
                Attack.enabled = false;
        }
    }
}
