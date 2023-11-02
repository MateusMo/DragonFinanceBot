using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFinanceBot.Menu
{
    public class FinanceMenu
    {
        public static string ShowMenu()
        {
            string menu = @"
            1 - Buscar altas e baixas no infomoney
            2 - Buscar preço de criptos na coinmaketcap
            3 - Fogo do dragão 
            4 - Sair
";
            return menu;
        }
    }
}
