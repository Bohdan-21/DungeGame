using Scripts.SaveData.Storage;
using UnityEngine;

namespace Scripts.GameMechanic.Item
{
    public class Item : MonoBehaviour
    {
        //TODO: remove enum
        public TypeItem TypeItem;
        public ItemCountData ItemCountData;

        public void PickUp()
        {
            Destroy(gameObject);
        }
    }
}
