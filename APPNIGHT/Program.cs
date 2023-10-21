using APPNIGHT.Entity;
using APPNIGHT.Helpers;
using MySql.Data.MySqlClient;

namespace APPNIGHT
{
    internal class Program
    {

            static void Main(string[] args)
            {
                try
                {
                    Menu menu = new Menu();
                    menu.MostrarMenuPrincipal();
                    
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro MySql");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro");
                    Console.WriteLine(ex.Message);
                }
            }
        
    }
}