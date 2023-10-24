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
                    MostrarMenuPrincipal();
                        break;
                    case 2:
                        crud.Create();
                    MostrarMenuPrincipal();
                    break;
                    case 3:
                        crud.Update();
                    MostrarMenuPrincipal();
                    break;
                    case 4:
                        crud.Delete();
                    MostrarMenuPrincipal();
                    break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA! TECLE ENTER PARA CONTINUAR.");
                        Console.ReadLine();
                        MostrarMenuCrud(crud);
                        break;
                }
            Console.Clear();
            Console.WriteLine("ATÉ MAIS!");
        }
        private int MenuCrud()
        {
            Console.Clear();
            Console.WriteLine("ESTABELECIMENTOS");
            Console.WriteLine("O QUE DESEJA FAZER?");
            Console.WriteLine("1 - Visualizar");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Sair");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}

