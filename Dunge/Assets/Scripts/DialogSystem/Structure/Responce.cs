using System;

namespace Scripts.DialogSystem.Structure
{
    [Serializable]
    public class Responce
    {
        public int id;
        public Speaker speaker;
        public string text;
        public int nextDialogId;
    }
}