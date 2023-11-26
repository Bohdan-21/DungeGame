using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using Zenject;
using Scripts.StaticData.Dialog;
using Scripts.GameSystem.DialogSystem;
using Scripts.GameSystem.DialogSystem.Logic;

namespace Scripts.GameSystem.DialogSystem.Logic.UIController
{
    /// <summary>
    /// как только получена команда на отображение диалога действуем следующим образом
    /// 
    /// 1 отобразить начальную фразу (отобразить сперва кто является спикером, и только после
    ///   этого вывести текст, и перевести систему в режим ожидания.
    /// 
    /// 2 Подготовка ответа. Отвечающий может быть как тот кто первый говорил, так и его
    ///   опонент. Подготовка ответа:
    ///     1 Убедиться что продолжение диалога вообще существует если его нету тогда диалог
    ///       нужно прервать, но прерывание нужно делать только после того как пользователь 
    ///       подтвердит это нажатием левой кнопки мышки, другими словами режим ожидания.
    ///       
    ///     2 Если диалог существует нужно определиться кто является ответчиком:
    ///         1 Ответчиком является игрок. В этой ситуации угроку нужно отобразить все 
    ///           возможные варианты ответов, которые он может выбрать. И ожидать до тех пор
    ///           пока игрок не выберет конкретный ответ. После выбора панель ответов должна
    ///           очиститься, и вывестись ответ выбраный игроком, и система должна перейти в 
    ///           режим ожидания.
    ///           
    ///         2 Ответчиком является нпс. Система должна рандомно выбрать один из возможных 
    ///           вариантов ответа игроку. И отобразить его, после чего снова перейти в режим 
    ///           ожидания
    ///           
    ///         ... Сперва отобразить кто является спикером, а только после этого вывести текст.
    ///           
    ///     3 Отправить ответ в управлюющий модуль который в зависимости от ответа либо завершит
    ///       диалог, либо же передаст запрашиваемый диалог системой
    /// 
    /// Судя по тому что я вижу здесь слишком много зависимостей, и этот компонент можно еще улучшить
    ///     1 сперва нужно вынести логику ожидания в отдельный компонент это упростит текущий компонент
    ///     2 еще как вариант это вынести спавн ответов в отдельный компонент, но это еще нужно расмотреть более детально
    /// 
    /// отображение
    /// ожидание
    /// спавн ответов
    /// управление ответами
    /// 
    /// </summary>
    public class DialogUI : MonoBehaviour, IDialogUI
    {
        [SerializeField] private WaitingButton _waitingButton;
        [SerializeField] private TextDisplayer _textDisplayer;
        [SerializeField] private AnswerPanel _answerPanel;

        public IDialogTracking _dialogTracker;
        public GameObject RootComponent;

        private Dialog _dialog;
        private int _cacheResponceId;

        [Inject]
        private void Construct(IDialogTracking dialogTracker)
        {
            _dialogTracker = dialogTracker;
        }

        private void Start()
        {
            HideUI();
        }

        public void Show(Dialog dialog)
        {
            InitializeValue(dialog);

            PrepareDialogUI();

            StartCoroutine(ShowDialog());
        }

        private void InitializeValue(Dialog dialog)
        {
            _cacheResponceId = -1;

            _dialog = dialog;
        }

        private void PrepareDialogUI()
        {
            _answerPanel.HideAnswerPanel();

            _waitingButton.DeactivateAndRemoveAllListener();
        }

        private IEnumerator ShowDialog()
        {
            yield return DisplayText(_dialog.speakerDialog.ToString(), _dialog.text);

            _waitingButton.ActivateAndAddListener(callback: PrepareResponce);
        }

        private IEnumerator DisplayText(string speakerName, string speakerText)
        {
            _textDisplayer.DisplaySpeakerName(speakerName);

            yield return _textDisplayer.DisplaySpeakerText(speakerText);
        }


        private void PrepareResponce()
        {
            _waitingButton.DeactivateAndRemoveAllListener();

            if (DoesHaveResponces())
            {
                Speaker speakerResponce = DetectSpeakerResponce();

                if (speakerResponce == Speaker.NPC)
                    SelectRandomResponce();
                else if (speakerResponce == Speaker.Player)
                    DisplayResponce();
            }
            else
                SendResponce(-1);
        }

        private bool DoesHaveResponces() =>
            _dialog.responces != null && _dialog.responces.Count != 0;

        private Speaker DetectSpeakerResponce() =>
            _dialog.speakerResponce;


        private void SelectRandomResponce()
        {
            int randomResponce = Random.Range(0, _dialog.responces.Count);

            DisplaySelectedResponce(_dialog.responces[randomResponce]);
        }


        private void DisplayResponce()
        {
            _answerPanel.ShowAnswerPanel();

            _answerPanel.InstantiateResponce(_dialog.responces, callback: ResponceSelected);
        }

        private void ResponceSelected(Responce responce)
        {
            _answerPanel.HideAnswerPanel();

            _answerPanel.CleanResponce();

            DisplaySelectedResponce(responce);
        }


        private void DisplaySelectedResponce(Responce responce)
        {
            CacheResponceId(responce);

            StartCoroutine(DisplayResponceText(responce));
        }

        private void CacheResponceId(Responce responce) =>
            _cacheResponceId = responce.id;

        private IEnumerator DisplayResponceText(Responce responce)
        {
            yield return DisplayText(_dialog.speakerResponce.ToString(), responce.text);

            _waitingButton.ActivateAndAddListener(callback: SendResponce);
        }


        private void SendResponce()
        {
            _waitingButton.DeactivateAndRemoveAllListener();

            SendResponce(_cacheResponceId);
        }

        private void SendResponce(int responceId) =>
            _dialogTracker.DialogResponce(responceId);


        public void EndDialog() =>
            SendResponce(-1);

        public void ShowUI() =>
            RootComponent.SetActive(true);

        public void HideUI()
        {
            StopAllCoroutines();

            _waitingButton.DeactivateAndRemoveAllListener();

            _textDisplayer.CleanTextComponent();

            _answerPanel.HideAnswerPanel();
            _answerPanel.CleanResponce();

            RootComponent.SetActive(false);
        }
    }
}