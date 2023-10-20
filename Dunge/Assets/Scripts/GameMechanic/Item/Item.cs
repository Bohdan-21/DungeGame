using Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.GameMechanic.Item
{
    public class Item : MonoBehaviour
    {
        public TypeItem TypeItem;

        public void PickUp()
        {
            Destroy(gameObject);
        }
    }
}
