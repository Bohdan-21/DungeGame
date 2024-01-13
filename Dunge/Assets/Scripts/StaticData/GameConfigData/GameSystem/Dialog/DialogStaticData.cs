using Scripts.LanguageLocalization;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.Dialog
{
    [CreateAssetMenu(fileName = "Dialog", menuName = "StaticData/GameConfigData/GameSystem/Dialog/Dialog")]
    public class DialogStaticData : ScriptableObject
    {
        public bool ShowOneTime = false;
        public List<DialogVariation> dialog;

        public DialogVariation GetDialogVariationByCurrentLanguage(Language language)
        {
            foreach (DialogVariation dialogVariation in dialog)
                if (dialogVariation.language == language)
                    return dialogVariation;
            return null;
        }
    }
}