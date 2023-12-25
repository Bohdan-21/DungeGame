using Scripts.SaveData.Storage;
using UnityEngine;

namespace Scripts.Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Storage _storage;

        public Storage GetStorage() =>
            _storage;
    }
}