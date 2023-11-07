using Scripts.Enemy;
using Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.QuestSystem
{
    public class PlayerQuestObserver : MonoBehaviour
    {
        //public PlayerAttack playerAttack;
        //public PlayerHealth playerHealth;


        private void Start()
        {
            //playerAttack.KillEvent += PlayerKillEvent;
            //playerHealth.HealingEvent += PlayerHealingEvent;
        }

        private void PlayerHealingEvent()
        {
            throw new System.NotImplementedException();
        }

        private void PlayerKillEvent(EnemyType enemyType)
        {
            throw new System.NotImplementedException();
        }
    }
}