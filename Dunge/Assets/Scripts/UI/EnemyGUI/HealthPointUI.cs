using Scripts.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.EnemyGUI
{
    public class HealthPointUI : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private Image _currentHealthImage;

        private void Update()
        {
            _currentHealthImage.fillAmount = GetFillAmount();
        }

        private float GetFillAmount()
        {
            return (float)_enemyHealth.CurrentHP / (float)_enemyHealth.MaxHP;
        }
    }
}