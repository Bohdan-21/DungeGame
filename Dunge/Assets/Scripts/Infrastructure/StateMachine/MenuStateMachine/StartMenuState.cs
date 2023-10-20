using Scripts.UI.MainMenu;
using System;

namespace Scripts.Infrastructure.StateMachine.MenuStateMachine
{
    public class StartMenuState : IState
    {
        private MainMenu _mainMenu;

        public StartMenuState(MainMenu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public void Enter()
        {
            _mainMenu.Show();
        }

        public void Exit()
        {
            _mainMenu.Hide();
        }
    }
}
