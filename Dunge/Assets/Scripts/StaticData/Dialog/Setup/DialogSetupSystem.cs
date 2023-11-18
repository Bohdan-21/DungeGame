using UnityEngine;

namespace Scripts.StaticData.Dialog.Setup
{
    [CreateAssetMenu(fileName = "DialogSetupSystem", menuName = "StaticData/Dialog/Setup/DialogSetupSystem")]
    public class DialogSetupSystem : ScriptableObject
    {
        public GameObject DialogUIPrefab;
        public GameObject InteractionPanerPrefab;
    }
}