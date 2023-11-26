using Scripts.GameSystem.ExperienceSystem.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.GameSystem.ExperienceSystem
{
    class ExperienceGiver : MonoBehaviour
    {
        public int expForGive = 1000;

        [ContextMenu("GiveExp")]
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                PlayerExperience.Instance.AddExperience(expForGive);
            }
        }
    }
}
