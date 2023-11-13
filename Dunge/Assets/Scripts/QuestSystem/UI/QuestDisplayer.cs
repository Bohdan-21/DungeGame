using Scripts.QuestSystem.QuestVariation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Scripts.QuestSystem.UI
{
    public class QuestDisplayer : MonoBehaviour
    {
        private Quest _quest;
        public TextMeshProUGUI text;

        private Action<Quest> _callback;

        public void Initialize(Quest quest, Action<Quest> callback)
        {
            _quest = quest;

            text.text = quest.nameQuest;

            _callback = callback;
        }

        public void ClickToSelect() => 
            _callback.Invoke(_quest);
    }
}