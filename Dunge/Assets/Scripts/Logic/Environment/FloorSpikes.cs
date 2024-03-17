using Assets.Scripts.StaticData.GameConfigData.Environment;
using Scripts.Infrastructure.Audio;
using Scripts.Player;
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
            if(obj.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _spikesAnimator.SetBool(Hash_ShowSpikes, true);

                PlayerBehaviour playerBehaviour = obj.GetComponent<PlayerBehaviour>();

                if (playerBehaviour != null)
                    playerBehaviour.Health.TakeDamage(_environmentData.SpikesDamage);
            }
        }

        private void OnTriggerExit(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _spikesAnimator.SetBool(Hash_ShowSpikes, false);
            }
        }
    }
}
