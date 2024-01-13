using System;
using Scripts.LanguageLocalization;

namespace Scripts.StaticData.GameConfigData.GameSystem.Dialog
{
    [Serializable]
    public class DialogVariation
    {
        public Language language;
        public DialogList dialogList;
    }
}