using System;
using System.Collections.Generic;

namespace Scripts.DialogSystem.Structure
{
    [Serializable]
    public class Dialog
    {
        public int id;
        public Speaker speaker;
        public string text;
        public List<Responce> responces;
    }
}