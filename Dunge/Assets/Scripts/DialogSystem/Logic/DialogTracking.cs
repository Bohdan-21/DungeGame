using Scripts.DialogSystem.Logic.UIController;
using Scripts.QuestSystem.Factory;
using Scripts.StaticData.Dialog;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.DialogSystem.Logic
{
    /// <summary>
    ///это может быть обычный класс который просто отслежывает текущее состояние 
    ///диалога, и побольшей степени он является просто связующим звеном
    /// </summary>
    public class DialogTracking : IDialogTracking
    {
        private IDialogUI _dialogUI;
        private QuestFactory _questFactory;
        private IDialogInitializer _dialogInitializer;

        private DialogVariation _dialogVariation = null;
        private Dialog _currentDialog = null;

        [Inject]
        private void Construct(IDialogUI dialogUI, QuestFactory questFactory, IDialogInitializer dialogInitializer)
        {
            _dialogUI = dialogUI;
            _questFactory = questFactory;
            _dialogInitializer = dialogInitializer;
        }

        public void StartDialogTracking(DialogVariation dialog)
        {
            _dialogVariation = dialog;

            ShowFirstDialog();
        }

        private void ShowFirstDialog()
        {
            GetFirstDialog();

            _dialogUI.ShowUI();

            _dialogUI.Show(_currentDialog);
        }

        private void GetFirstDialog() => 
            _currentDialog = _dialogVariation.dialogList.dialogs[0];

        public void DialogResponce(int responceId)
        {
            if (responceId == -1)
                _dialogInitializer.InteruptDialog();
            else
            {
                _currentDialog = GetNextDialog(responceId);

                if (_currentDialog == null)
                    _dialogInitializer.InteruptDialog();
                else
                    _dialogUI.Show(_currentDialog);
            }
        }

        private Dialog GetNextDialog(int responceId)
        {
            Responce currentResponce = GetCurrentResponce(responceId);

            if (currentResponce == null)
                return null;

            TryActivateQuest(currentResponce.questId);

            return FindNextDilog(currentResponce.nextDialogId);
        }

        private Responce GetCurrentResponce(int responceId)
        {
            foreach (Responce responce in _currentDialog.responces)
                if (responce.id == responceId)
                    return responce;
            return null;
        }
        
        private void TryActivateQuest(int questId)
        {
            if (questId != -1)
                _questFactory.SpawnNewQuestByID(questId);
        }

        private Dialog FindNextDilog(int dialogId)
        {
            int count = _dialogVariation.dialogList.dialogs.Count;

            for (int i = 0; i < count; i++)
                if (_dialogVariation.dialogList.dialogs[i].id == dialogId)
                    return _dialogVariation.dialogList.dialogs[i];
            return null;
        }


        public void EndDialogTracking()
        {
            _dialogVariation = null;
            _currentDialog = null;

            _dialogUI.HideUI();
        }
    }
}
