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
        private EstabelecimentoModel _estabelecimentoModel = new EstabelecimentoModel();
        public void MostrarMenuPrincipal()
        {
            MostrarMenuCrud(_estabelecimentoModel);
        }
        private void MostrarMenuCrud(ICrud crud)
        {

            switch (MenuCrud())
            {
                case 1:
                    crud.Read();
                    break;
                case 2:
                    crud.Create();
                    break;
                case 3:
                    crud.Update();
                    break;
                case 4:
                    crud.Delete();
                    break;
                default:
                    Console.WriteLine("Opção invalida, precione uma tecla para continuar");
                    Console.ReadLine();
                    MostrarMenuCrud(crud);
                    break;
            }
        }
        private int MenuCrud()
        {
            Console.Clear();

            Console.WriteLine("1 - Visualizar");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Excluir");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}

