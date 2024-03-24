using Assets.Scripts.StaticData.GameConfigData.Environment;
using Scripts.Player;
using Scripts.Services.AudioService.SoundService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Logic.Environment
{
    class FloorSpikes : MonoBehaviour
    {
        private readonly int Hash_ShowSpikes = Animator.StringToHash("ShowSpikes");

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private Animator _spikesAnimator;

        private ISoundsGameActionPlayer _soundsGame;
        private EnvironmentData _environmentData;

        private int _countPersonWhoActivateTrigger = 0;//TODO: maybe rewrite this

        [Inject]
        private void Construct(ISoundsGameActionPlayer soundsGame, EnvironmentData environmentData)
        {
            _soundsGame = soundsGame;
            _environmentData = environmentData;
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
                {
                    _spikesAnimator.SetBool(Hash_ShowSpikes, true);

                    IHealth health = obj.gameObject.GetComponent<IHealth>();

                    if (health != null)
                        health.TakeDamage(_environmentData.SpikesDamage);
                }
                _countPersonWhoActivateTrigger++;
            }
        }

        private void OnTriggerExit(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("Player") || obj.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                _countPersonWhoActivateTrigger--;
                if (_countPersonWhoActivateTrigger == 0)
                {
                    _spikesAnimator.SetBool(Hash_ShowSpikes, false);
                }
            }
        }
    }
}
