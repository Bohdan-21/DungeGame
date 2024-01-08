using Scripts.GameSystem.DialogSystem.Logic.UIController;
using Scripts.GameSystem.QuestSystem.UI.QuestJournal;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using UnityEngine;
using Zenject;

namespace Scripts.UI.GameUI.UIHandler
{
    public class GUIHandler : ITickable
    {


        [Inject]
        private void Construct(IQuestJournalUI questJournalUI, IDialogUI dialogUI, ITraiderUI traiderUI)
        {

        }

        public void Tick()
        {
            
        }
    }
}
