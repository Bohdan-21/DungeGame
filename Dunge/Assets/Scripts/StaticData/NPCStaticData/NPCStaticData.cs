using Scripts.NPC;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.NPCStaticData
{
    [CreateAssetMenu(fileName = "NPCReferenceStaticData", menuName = "StaticData/NPCReferenceStaticData")]
    public class NPCStaticData : ScriptableObject
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
