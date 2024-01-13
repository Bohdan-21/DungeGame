using Scripts.DialogSystem;
using System;

namespace Scripts.StaticData.GameConfigData.GameSystem.Dialog
{
    [Serializable]
    public class Responce
    {
        public int id;
        public string text;
        public int questId = -1;
        public int nextDialogId;
    }
}