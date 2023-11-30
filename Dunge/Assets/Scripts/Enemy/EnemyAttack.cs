using Scripts.GameSystem.StatsSystem.Handler;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.Infrastructure.Audio;
using Scripts.Logic;
using Scripts.Player;
using Scripts.StaticData.EnemyStaticData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;

        [SerializeField] private EnemyStatsHandler _enemyStatsHandler;

        public EnemyAnimator Animator;
        public NavMeshAgent Agent;
        public EnemyHealth Health;
        
        private Collider[] _hits = new Collider[1];
        private Transform _playerTransform;
        private ISoundsGameActionPlayer _soundPlayer;

        private int _layerMask;
        private bool _isAttacking;

        private float _cooldown;
        private float _currentCoolDownTime;

        private float _attackRadius;
        private float _attackDistance;
        
        private int _damage;

        [Inject]
        private void Construct(EnemyStaticData config, PlayerBehaviour player, ISoundsGameActionPlayer soundPlayer)
        {
            _damage = config.AtackData.Damage;
            _cooldown = config.AtackData.CooldownAtack;
            _attackRadius = config.AtackData.AttactRadius;
            _attackDistance = config.AtackData.AttackDistance;

            _playerTransform = player.transform;

            _soundPlayer = soundPlayer;
        }

        private void Awake()
        {
            _enemyStatsHandler.UpdateStatsEvent += UpdateStats;

            _layerMask = 1 << LayerMask.NameToLayer("Player");
            _currentCoolDownTime = 0;
            _isAttacking = false;
        }

        private void OnDestroy() => 
            _enemyStatsHandler.UpdateStatsEvent -= UpdateStats;

        private void UpdateStats()
        {
            _damage = (int)_enemyStatsHandler.GetStatDataByType(TypeStat.Damage).GetCurrentValue();
        }

        private void Start()
        {
            Health.HealthChanged += HealthChanged;
        }


        private void Update()
        {
            transform.LookAt(_playerTransform);

            UpdateCooldownTime();

            if (IsCooldownIsEnd() && !_isAttacking)
                StartAttack();
        }

        private void StartAttack()
        {
            if (IsNotMove())
            {
                Animator.PlayAttack();
                _isAttacking = true;
            }
        }

        private void OnAttack()//Unity Event Search in animation clip
        {
            PlaySound();

            int hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), _attackRadius, _hits, _layerMask);

            Hit(hitAmount);
        }

        private void EndAttack()//Unity Event Search in animation clip
        {
            _currentCoolDownTime = _cooldown;
            _isAttacking = false;
        }

        private void PlaySound() => 
            _soundPlayer.PlayAttackEnemySound();

        private void HealthChanged()
        {
            if (IsCooldownIsEnd())
                _isAttacking = false;
        }

        private void UpdateCooldownTime()
        {
            if (!IsCooldownIsEnd())
                _currentCoolDownTime -= Time.deltaTime;
        }

        private bool IsCooldownIsEnd()
        {
            return _currentCoolDownTime <= 0f;
        }

        private Vector3 StartPoint()
        {
            Vector3 startPoint = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            return startPoint + (transform.forward * _attackDistance);
        }

        private void Hit(int hitAmount)
        {
            if (hitAmount > 0)
            {
                Collider hit = _hits[0];

                hit.GetComponent<IHealth>().TakeDamage(_damage);
            }
        }

        private bool IsNotMove() =>
            Agent.velocity.magnitude < MinimalVelocity;
    }
}