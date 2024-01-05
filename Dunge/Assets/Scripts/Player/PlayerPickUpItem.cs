using Scripts.GameMechanic.ItemSystem;
using Scripts.Infrastructure.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    class PlayerPickUpItem : MonoBehaviour
    {
        public CharacterController CharacterController;
        public Inventory Inventory;

        private Collider[] _findItems = new Collider[5];
        private ISoundsGameActionPlayer _soundPlayer;

        private float _searchRadius = 2.5f;
        private int _layerMask;

        [Inject]
        private void Construct(ISoundsGameActionPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        private void Start()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Picked");
        }

        private void Update()
        {
            int itemAmount = FindItems();

            PickUpAllItems(itemAmount);
        }

        private int FindItems() =>
            Physics.OverlapSphereNonAlloc(transform.position, _searchRadius, _findItems, _layerMask);

        private void PickUpAllItems(int itemAmount)
        {
            for (int i = 0; i < itemAmount; i++)
            {
                ItemMarker item = _findItems[i].GetComponent<ItemMarker>();

                Inventory.AddItem(item);
                PlaySound();
            }
        }

        private void PlaySound() => 
            _soundPlayer.PlayPickUpItemSound();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(transform.position, _searchRadius);

            Gizmos.color = Color.white;
        }
    }
}
