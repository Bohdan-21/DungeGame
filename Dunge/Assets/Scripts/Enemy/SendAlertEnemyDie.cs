using Scripts.QuestSystem.Channel;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Enemy
{
    public class SendAlertEnemyDie : MonoBehaviour
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private EnemyDeath _enemyDeath;

        private CombatChannel _combatChannel;

        [Inject]
        private void Construct(CombatChannel combatChannel) => 
            _combatChannel = combatChannel;

        private void Start() => 
            _enemyDeath.EnemyDie += EnemyDie;

        private void OnDestroy() =>
            _enemyDeath.EnemyDie -= EnemyDie;

        private void EnemyDie() => 
            _combatChannel.InvokeKillEvent(_enemyType);
    }
}
