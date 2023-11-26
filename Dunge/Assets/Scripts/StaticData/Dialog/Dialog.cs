using Scripts.GameSystem.DialogSystem;
using System;
using System.Collections.Generic;

namespace Scripts.StaticData.Dialog
{
    [Serializable]
    public class Dialog
    {
        public int id;
        public Speaker speakerDialog;
        public Speaker speakerResponce;
        public string text;
        public List<Responce> responces;
    }
}