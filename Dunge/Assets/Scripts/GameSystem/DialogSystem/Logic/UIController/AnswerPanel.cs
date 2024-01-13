using Scripts.StaticData.GameConfigData.GameSystem.Dialog;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.GameSystem.DialogSystem.Logic.UIController
{
    public class AnswerPanel : MonoBehaviour
    {
        [SerializeField] private GameObject AnswerDisplayRootComponent;
        [SerializeField] private Transform Content;

        public GameObject AnswerVariantionPrefab;

        private List<ResponceVariant> responcesVariant = new List<ResponceVariant>();

        public void ShowAnswerPanel() =>
            AnswerDisplayRootComponent.SetActive(true);

        public void HideAnswerPanel() =>
            AnswerDisplayRootComponent.SetActive(false);

        public void InstantiateResponce(List<Responce> responces, Action<Responce> callback)
        {
            foreach (Responce responce in responces)
            {
                ResponceVariant resp = Instantiate(AnswerVariantionPrefab, Content).GetComponent<ResponceVariant>();

                resp.InitializeResponce(responce, callback: callback);

                responcesVariant.Add(resp);
            }
        }

        public void CleanResponce()
        {
            foreach (ResponceVariant responce in responcesVariant)
                Destroy(responce.gameObject);
            responcesVariant.Clear();
        }
    }
}