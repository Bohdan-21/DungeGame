using System;
using Scripts.GameLanguage;

namespace Scripts.DialogSystem.Structure
{
    [Serializable]
    public class DialogVariation
    {
        public Language language;
        public DialogList dialogList;
    }
}