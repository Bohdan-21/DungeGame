using Scripts.GameLanguage;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.Dialog
{
    [CreateAssetMenu(fileName = "DialogStaticData", menuName = "StaticData/Dialog/DialogStaticData")]
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