using Scripts.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.GameSystem.QuestSystem.Channel
{
    class CombatChannel
    {
        public event Action<EnemyType> KillEvent;

        public void InvokeKillEvent(EnemyType enemyType) =>
            KillEvent?.Invoke(enemyType);
    }
}
