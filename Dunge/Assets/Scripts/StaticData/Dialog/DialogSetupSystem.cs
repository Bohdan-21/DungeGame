using UnityEngine;

namespace Scripts.StaticData.Dialog
{
    [CreateAssetMenu(fileName = "DialogSetupSystem", menuName = "StaticData/Dialog/DialogSetupSystem")]
    public class DialogSetupSystem : ScriptableObject
    {
        public GameObject DialogUIPrefab;
        public GameObject InteractionPanerPrefab;
    }
}