using System;
using Scripts.GameLanguage;

namespace Scripts.StaticData.Dialog
{
    [Serializable]
    public class DialogVariation
    {
        public Language language;
        public DialogList dialogList;
    }
}