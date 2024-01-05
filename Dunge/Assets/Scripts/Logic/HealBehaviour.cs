using Scripts.GameMechanic.ItemSystem;
using Scripts.Player;

namespace Scripts.Logic
{
    public class HealBehaviour
    {
        public void Healing(TypeItem typeItem, PlayerHealth health)
        {
            switch (typeItem)
            {
                case TypeItem.SMALL_HEAL:
                    health.Heal(25);
                    break;
                case TypeItem.MIDDLE_HEAL:
                    health.Heal(50);
                    break;
                case TypeItem.LARGE_HEAL:
                    health.Heal(100);
                    break;
            }
        }
    }
}