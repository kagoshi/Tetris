using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal static class BezRaznici
    {
        public static Form2 MainMenu
        {
            get 
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new Form2();
                }
                return _mainMenu;
            }
        }
        private static Form2 _mainMenu;
    }
}
