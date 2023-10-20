using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI.Curtain
{
    public class Curtain : MonoBehaviour, ICurtain
    {
        public CanvasGroup curtain;

        public void Show()
        {
            gameObject.SetActive(true);
            curtain.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(DelayHide());
        }

        private IEnumerator DelayHide()
        {
            while(curtain.alpha > 0)
            {
                curtain.alpha -= 0.05f;
                yield return new WaitForSeconds(0.03f);
            }
            gameObject.SetActive(false);
        }
    }
}