using UnityEngine;
using TMPro;
using System.Collections;

namespace Scripts.GameSystem.DialogSystem.Logic.UIController
{
    public class TextDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI speakerName;
        [SerializeField] private TextMeshProUGUI speakerText;

        public void DisplaySpeakerName(string speaker) =>
            speakerName.text = speaker;

        public IEnumerator DisplaySpeakerText(string text)
        {
            speakerText.text = "";

            foreach (char symbol in text)
            {
                speakerText.text += symbol;

                yield return new WaitForSeconds(0.01f);
            }
        }

        public void CleanTextComponent() =>
            speakerName.text = speakerText.text = "";
    }
}