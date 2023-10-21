using APPNIGHT.Entity;
using APPNIGHT.Helpers;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPNIGHT.Model
{
    public class EstabelecimentoModel : DataBase, ICrud
    {
            

public void Create()
        {
            EstabelecimentoEntity estabelecimento = new EstabelecimentoEntity();
            Console.WriteLine("Digite o nome do seu estabelecimento:");
            estabelecimento.NOME = Console.ReadLine();
            Console.WriteLine("Digite o endereço do seu estabelecimento:");
            estabelecimento.ENDERECO = Console.ReadLine();
            Console.WriteLine("Digite o primeiro dia da semana de funcionamento:");
            estabelecimento.SEMANA_INICIO = Console.ReadLine();
            Console.WriteLine("Digite o último dia da semana de funcionamento:");
            estabelecimento.SEMANA_FINAL = Console.ReadLine();
            Console.WriteLine("Digite o número máximo de pessoas para o seu estabelecimento:");
            estabelecimento.LOTACAO = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o número de mesas no estabelecimento:");
            estabelecimento.QUANTIDADE_MESAS = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o preço da entrada:");
            estabelecimento.PRECO_ENTRADA = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Digite o número de vagas de estacionamento do seu estabelecimento:");
            estabelecimento.VAGAS_ESTACIONAMENTO = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o primeiro dia da semana de funcionamento");

            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "INSERT INTO ESTABELECIMENTO VALUE (NULL, @NOME, @ENDERECO, @SEMANA_INICIO, @SEMANA_FINAL, @LOTACAO, " +
                    "@QUANTIDADE_MESAS, @PRECO_ENTRADA, @VAGAS_ESTACIONAMENTO)";
                int linhas = connection.Execute(sql, tipo);
                Console.WriteLine($"Tipo inserido - {linhas} linhas afetadas");
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
