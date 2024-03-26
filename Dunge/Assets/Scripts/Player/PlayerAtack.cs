using Scripts.GameSystem.StatsSystem.Handler;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.Logic;
using Scripts.Services.AudioService.SoundService;
using Scripts.Services.ControlButtonService;
using Scripts.Services.InputBlockerService;
using Scripts.Services.InputService;
using Scripts.Services.InteruptService;
using Scripts.StaticData.GameConfigData.Player;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerAtack : MonoBehaviour, IInputBlockerHandler
    {
        private KeyCode AttackButton;

        [SerializeField] private PlayerAnimator PlayerAnimator;
        [SerializeField] private PlayerStatsHandler _statsHandler;

        private Collider[] _hits = new Collider[3];
        
        private IInputService _inputService;
        private IInputBlockerService _inputBlockerService;
        
        private ISoundsGameActionPlayer _soundPlayer;

        private bool _isInputBlock;

        private int _layerMask;
        private float _attackRadius = 1;
        private int _damage;

        [Inject]
        private void Construct(IInputService inputService, PlayerCharacterConfig config,
                               ISoundsGameActionPlayer soundPlayer, IControlButtonService controlButtons, 
                               IInputBlockerService inputBlockerService)
        {
            _inputService = inputService;
            _inputBlockerService = inputBlockerService;

            _soundPlayer = soundPlayer;

            _attackRadius = config.AttackRadius;

            AttackButton = controlButtons.ControlButtons.PlayerControlButtons.AttackControlButtons.AttackButton;
        }

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Enemy");
            _isInputBlock = false;

            _inputBlockerService.AddHandler(this);
        }

        private void Start()
        {
            UpdateStats();

            _statsHandler.UpdateStatsEvent += UpdateStats;
        }

        private void OnDestroy()
        {
            _inputBlockerService.RemoveHandler(this);

            _statsHandler.UpdateStatsEvent -= UpdateStats;
        }


        private void Update()
        {
            if (_isInputBlock)
                return;
            StartAttack();
        }

        private void StartAttack()
        {
            if (_inputService.IsPress(AttackButton))
            {
                PlayerAnimator.PlayAttack();
            }
        }

        private void OnAttack()
        {
            PlaySound();

            int hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), _attackRadius, _hits, _layerMask);

            if (hitAmount > 0)
            {
                for (int i = 0; i < hitAmount; i++)
                {
                    _hits[i].transform.GetComponent<IHealth>().TakeDamage(_damage);
                }
            }
        }

        private void EndAttack()
        {

        }

        private Vector3 StartPoint()
        {
            Vector3 startPoint = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            return startPoint + transform.forward;
        }

        private void PlaySound() => 
            _soundPlayer.PlayAttackPlayerSound();

        private void UpdateStats() => 
            _damage = (int)_statsHandler.GetStatDataByType(TypeStat.Damage).GetCurrentValue();

        public void BlockInput()
        {
            _isInputBlock = true;
        }

        public void UnBlockInput()
        {
            _isInputBlock = false;
        }
    }
}