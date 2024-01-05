using Scripts.GameMechanic.ItemSystem;
using TMPro;
using UnityEngine;

namespace Scripts.Player
{
    class ItemUpdater : MonoBehaviour
    {
        public TextMeshProUGUI text;

        public TypeItem TypeItem;

        public void UpdateCount(int count)
        {
            text.text = count.ToString();
        }
    }

}
