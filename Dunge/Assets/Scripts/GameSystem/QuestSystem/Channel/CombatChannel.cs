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
        public event Action<EnemyType, int> KillEvent;

        public void InvokeKillEvent(EnemyType enemyType, int levelKilledMonster) =>
            KillEvent?.Invoke(enemyType, levelKilledMonster);
    }
}
