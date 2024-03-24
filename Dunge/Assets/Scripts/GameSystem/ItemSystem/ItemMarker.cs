using UnityEngine;

namespace Scripts.GameMechanic.ItemSystem
{
    public class ItemMarker : MonoBehaviour
    {
        public TypeItem TypeItem;

        public void PickUp()
        {
            Destroy(gameObject);
        }
    }
}
