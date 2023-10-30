using UnityEngine;
using TMPro;
using System;
using Scripts.DialogSystem.Structure;

namespace Scripts.DialogSystem.Logic
{
    public class ResponceVariant : MonoBehaviour
    {
        public TextMeshProUGUI responceId;
        public TextMeshProUGUI responseText;

        private Responce _responce;
        private event Action<Responce> _callback;

        public void InitializeResponce(Responce responce, Action<Responce> callback)
        {
            _responce = responce;
            _callback += callback;

            responceId.text = responce.id.ToString();
            responseText.text = responce.text;
        }

        public void ClickResponce()
        {
            _callback.Invoke(_responce);
        }
    }
}