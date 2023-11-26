using UnityEngine;
using TMPro;

namespace Scripts.GameSystem.SkillTreeSystem.UI
{
    public class PointDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI SkillPointText;
        [SerializeField] private TextMeshProUGUI AttributePointText;

        public void ShowSkillPoint(int skillPoint, int attributePoint)
        {
            SkillPointText.text = skillPoint.ToString();
            AttributePointText.text = attributePoint.ToString();
        }
    }
}