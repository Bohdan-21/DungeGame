using Scripts.Infrastructure.Audio;
using UnityEngine;
using Zenject;

namespace Scripts.Logic.Environment
{
    class Door : MonoBehaviour
    {
        private readonly int Hash_IsDoorOpen = Animator.StringToHash("IsDoorOpen");

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private Animator _doorAnimator;

        private ISoundsGameActionPlayer _soundsGame;

        private int _countPersonWhoActivateTrigger = 0;//TODO:maybe rewrite this

        [Inject]
        private void Construct(ISoundsGameActionPlayer soundsGame)
        {
            _soundsGame = soundsGame;
        }

        private void Start()
        {
            _triggerObserver.TriggerEnter += OnTriggerEnter;
            _triggerObserver.TriggerExit += OnTriggerExit;
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEnter -= OnTriggerEnter;
            _triggerObserver.TriggerExit -= OnTriggerExit;
        }

        private void OnTriggerEnter(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("Player") || obj.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if (_countPersonWhoActivateTrigger == 0)
                    _doorAnimator.SetBool(Hash_IsDoorOpen, true);

                _countPersonWhoActivateTrigger++;
            }
        }

        private void OnTriggerExit(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("Player") || obj.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                _countPersonWhoActivateTrigger--;
                
                if (_countPersonWhoActivateTrigger == 0)
                    _doorAnimator.SetBool(Hash_IsDoorOpen, false);
            }
        }
    }
}
