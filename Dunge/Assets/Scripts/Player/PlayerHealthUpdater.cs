using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.Player
{
    class PlayerHealthUpdater : MonoBehaviour
    {
        private PlayerHealth Health;

        [SerializeField] private Image updateImage;

        [Inject]
        private void Construct(PlayerBehaviour player)
        {
            Health = player.Health;
        }

        private void Start()
        {
            Health.UpdateHealth += UpdateHealth;

            UpdateHealth();
        }

        private void OnDestroy()
        {
            Health.UpdateHealth -= UpdateHealth;
        }

        private void UpdateHealth()
        {
            updateImage.fillAmount = GetFillAmount();
        }

        private float GetFillAmount()
        {
            return (float)Health.CurrentHP / (float)Health.MaxHP;
        }
    }
}
