using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.Dialog.Setup
{
    [CreateAssetMenu(fileName = "DialogSetupSystem", menuName = "StaticData/GameConfigData/GameSystem/Dialog/Setup/DialogSetupSystem")]
    public class DialogSetupSystem : ScriptableObject
    {
        public GameObject DialogUIPrefab;
        public GameObject InteractionPanerPrefab;
    }
}