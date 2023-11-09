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

        public void Initialize(Quest quest)
        {
            _quest = quest;

            text.text = quest.nameQuest;
        }
    }
}