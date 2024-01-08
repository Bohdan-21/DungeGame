using Scripts.GameSystem.DialogSystem.Logic.UIController;
using Scripts.GameSystem.QuestSystem.UI.QuestJournal;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.UI.GameUI.UIHandler
{
    public class GUIHandler : ITickable
    {
        private Dictionary<Type, UIMarker> _uiHandlers = new Dictionary<Type, UIMarker>();

        [Inject]
        private void Construct(IQuestJournalUI questJournalUI, IDialogUI dialogUI, ITraiderUI traiderUI)
        {
            _uiHandlers.Add(questJournalUI.GetType(), questJournalUI);
            _uiHandlers.Add(dialogUI.GetType(), dialogUI);
            _uiHandlers.Add(traiderUI.GetType(), traiderUI);
        }

        public void Tick()
        {
            
        }
    }
}
