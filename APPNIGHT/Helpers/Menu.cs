using APPNIGHT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPNIGHT.Helpers
{
    public class Menu
    {
        
        public int MenuCrud()
        {
            Console.Clear();

            Console.WriteLine("1 - Visualizar");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("0 - Retornar");
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}
