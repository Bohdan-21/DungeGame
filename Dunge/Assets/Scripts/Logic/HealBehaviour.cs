using Scripts.GameMechanic.Item;
using Scripts.Player;

namespace Scripts.Logic
{
    public class HealBehaviour
    {
        public void Healing(TypeItem typeItem, PlayerHealth health)
        {
            switch (typeItem)
            {
                case TypeItem.SMALL:
                    health.Heal(25);
                    break;
                case TypeItem.MIDDLE:
                    health.Heal(50);
                    break;
                case TypeItem.LARGE:
                    health.Heal(100);
                    break;
            }
        }
    }
}