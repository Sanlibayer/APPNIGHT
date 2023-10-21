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
            estabelecimento = Popular(estabelecimento);
            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "INSERT INTO ESTABELECIMENTO VALUE (NULL, @NOME, @ENDERECO, @HORARIO_FUNCIONAMENTO, @TIPO, @LOTACAO, " +
                    "@QUANTIDADE_MESAS, @PRECO_ENTRADA, @VAGAS_ESTACIONAMENTO)";
                int linhas = connection.Execute(sql, estabelecimento);
                Console.WriteLine($"Tipo inserido - {linhas} linhas afetadas");
            }
        }
        private EstabelecimentoEntity Popular(EstabelecimentoEntity estabelecimento)
        {
            Console.WriteLine("Digite o nome do seu estabelecimento:");
            estabelecimento.NOME = ConsoleHelpers.ChangeValue(estabelecimento.NOME);
            Console.WriteLine("Digite o endereço do seu estabelecimento:");
            estabelecimento.ENDERECO = ConsoleHelpers.ChangeValue(estabelecimento.ENDERECO);
            Console.WriteLine("Digite a horário de funcionamento do seu estabelecimento:");
            Console.WriteLine("Exemplo: 'Segunda à Sexta das 8:00 às 19:30'");
            estabelecimento.HORARIO_FUNCIONAMENTO = ConsoleHelpers.ChangeValue(estabelecimento.HORARIO_FUNCIONAMENTO);
            Console.WriteLine("Digite o tipo do seu estabelecimento:");
            Console.WriteLine("Exemplo: Balada, Restaurante, Pub, Pizzaria, etc");
            estabelecimento.TIPO = ConsoleHelpers.ChangeValue(estabelecimento.TIPO);
            Console.WriteLine("Digite o número máximo de pessoas para o seu estabelecimento:");
            estabelecimento.LOTACAO = ConsoleHelpers.ChangeValue(estabelecimento.LOTACAO); ;
            Console.WriteLine("Digite o número de mesas no estabelecimento:");
            estabelecimento.QUANTIDADE_MESAS = ConsoleHelpers.ChangeValue(estabelecimento.QUANTIDADE_MESAS);
            Console.WriteLine("Digite o preço da entrada:");
            estabelecimento.PRECO_ENTRADA = ConsoleHelpers.ChangeValue(estabelecimento.PRECO_ENTRADA);
            Console.WriteLine("Digite o número de vagas de estacionamento do seu estabelecimento:");
            estabelecimento.VAGAS_ESTACIONAMENTO = ConsoleHelpers.ChangeValue(estabelecimento.VAGAS_ESTACIONAMENTO);

            return estabelecimento;
        }

        public void Delete()
        {
            var parameters = new { Id = GetIndex() };
            string sql = "DELETE FROM ESTABELECIMENTO_2 WHERE ID = @ID";
            this.Execute(sql, parameters);
            Console.WriteLine("Produto excluido com sucesso");
        }
        private int GetIndex()
        {
            Read();
            Console.WriteLine("Digite o id para continuar");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void Read()
        {
            IEnumerable<EstabelecimentoEntity> estabelecimentos = GetEstabelecimento();
            foreach (EstabelecimentoEntity estabelecimento in estabelecimentos)
            {
                Console.WriteLine($"{estabelecimento.ID} - {estabelecimento.NOME} / {estabelecimento.TIPO}");
                Console.WriteLine($"Endereço: {estabelecimento.ENDERECO}");
                Console.WriteLine($"Máximo de pessoas: {estabelecimento.LOTACAO}");
                Console.WriteLine($"Horário de funcionamento: {estabelecimento.HORARIO_FUNCIONAMENTO}");
                Console.WriteLine($"Quantidade de mesas do local: {estabelecimento.QUANTIDADE_MESAS}");
                Console.WriteLine($"Valor da entrada: {estabelecimento.PRECO_ENTRADA}");
                Console.WriteLine($"Vagas de estacionamento: {estabelecimento.VAGAS_ESTACIONAMENTO}");

            }
        }
        private IEnumerable<EstabelecimentoEntity> GetEstabelecimento()
        {
            string sql = "SELECT * FROM ESTABELECIMENTO_2";
            return this.GetConnection().Query<EstabelecimentoEntity>(sql);
        }
        public void Update()
        {

        }

    }
}
