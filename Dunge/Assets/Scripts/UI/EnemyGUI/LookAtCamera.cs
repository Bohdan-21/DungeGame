using Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI.EnemyGUI
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _enemyDeath;
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
            _enemyDeath.EnemyDie += EnemyDie;
        }

        private void Update()
        {
            Quaternion rotation = _mainCamera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }

        private void EnemyDie()
        {
            gameObject.SetActive(false);
        }
    }
}