using APPNIGHT.Helpers;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

namespace APPNIGHT
{
    internal class Program
    {  
        static void Main(string[] args)
        {
            while (true)
            {           
                try
                {
                Menu menu = new Menu();
                menu.MostrarMenuPrincipal();
                break;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro MySql");
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.Write("\nDigite apenas números! Tecle ENTER para tentar novamente.");                  
                    Console.ReadLine();
                }
            }
        }       
    }
}