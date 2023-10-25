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
                        crud.Create();
                    MostrarMenuPrincipal();
                    break;
                    case 2:
                        crud.Read();
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
            Console.WriteLine("Nós dos APP Night agradecemos, conte sempre com a gente!");
            Console.WriteLine("\nA NOITE NA PALMA DE SUA MÃO!");
        }
        private int MenuCrud()
        {
            Console.Clear();
            Console.Title = "APP NIGHT";
            Console.WriteLine("\n------ APP NIGHT ------\n");
            Console.WriteLine("O que deseja fazer?\n");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Sair");
            Console.Write("\nDigite a opção desejada: ");
            return Convert.ToInt32(Console.ReadLine());       
        }
    }
}

