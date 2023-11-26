using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest;

namespace Scripts.GameSystem.QuestSystem.UI.QuestItemDisplayer
{
    public class QuestDisplayer : MonoBehaviour
    {
        private Quest _quest;
        public TextMeshProUGUI text;

        private Action<Quest> _callback;

        public void Initialize(Quest quest, Action<Quest> callback)
        {
            _quest = quest;

            text.text = quest.QuestData.NameQuest;

            _callback = callback;
        }

        public void ClickToSelect() =>
            _callback.Invoke(_quest);
    }
}