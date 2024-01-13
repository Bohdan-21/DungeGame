using Scripts.NPC;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.NPC
{
    [CreateAssetMenu(fileName = "NPCPrefabReference", menuName = "StaticData/GameConfigData/NPC/NPCPrefabReference")]
    public class NPCPrefabReference : ScriptableObject
    {
        [SerializeField] private List<NPCReference> NPCReferences;

        public GameObject GetReference(NPCType name)
        {
            foreach (NPCReference reference in NPCReferences)
                if (reference.NPCName == name)
                    return reference.Reference;
            return null;
        }
    }
}
