using Scripts.Logic;
using UnityEngine;

namespace Scripts.Enemy
{
    public class Aggro : MonoBehaviour
    {
        private const string LayerNameForPlayer = "Player";
        
        public EnemyMove Move;
        public EnemyDeath EnemyDeath;
        public TriggerObserver Observer;

        private bool _isEnemyDie;

        private void Start()
        {
            _isEnemyDie = false;
            Move.enabled = false;

            Observer.TriggerEnter += TriggerEnter;
            Observer.TriggerExit += TriggerExit;

            EnemyDeath.EnemyDie += EnemyDie;
        }

        private void EnemyDie()
        {
            _isEnemyDie = true;
            Move.enabled = false;
        }

        private void TriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(LayerNameForPlayer) && !_isEnemyDie)
                Move.enabled = true;
        }

        private void TriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(LayerNameForPlayer) && !_isEnemyDie)
                Move.enabled = false;
        }
    }
}