using APPNIGHT.Entity;
using APPNIGHT.Helpers;
using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
                string sql = "INSERT INTO ESTABELECIMENTO_2 VALUE (NULL, @NOME, @ENDERECO, @LOTACAO, " +
                    "@HORARIO_FUNCIONAMENTO, @VAGAS_ESTACIONAMENTO, " +
                    "@QUANTIDADE_MESAS, @PRECO_ENTRADA, @TIPO)";
                int linhas = connection.Execute(sql, estabelecimento);
                Console.WriteLine($"ESTABELECIMENTO INSERIDO COM SUCESSO!");
                Console.WriteLine("TECLE ENTER PARA CONTINUAR");
                Console.ReadLine();
            }
        }
        private EstabelecimentoEntity Popular(EstabelecimentoEntity estabelecimento)
        {
            while(true) 
            { 
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nCADASTRO DE ESTABELECIMENTO\n");
                    Console.Write("Digite o nome do seu estabelecimento: ");
                    estabelecimento.NOME = ConsoleHelpers.ChangeValue(estabelecimento.NOME);
                    Console.Write("Digite o endereço do seu estabelecimento: ");
                    estabelecimento.ENDERECO = ConsoleHelpers.ChangeValue(estabelecimento.ENDERECO);
                    Console.Write("Digite a horário de funcionamento do seu estabelecimento (Exemplo: 'Segunda à Sexta das 8:00 às 19:30'): ");
                    estabelecimento.HORARIO_FUNCIONAMENTO = ConsoleHelpers.ChangeValue(estabelecimento.HORARIO_FUNCIONAMENTO);
                    Console.Write("Digite o tipo do seu estabelecimento (Exemplo: Balada, Restaurante, Pub, Pizzaria, etc): ");
                    estabelecimento.TIPO = ConsoleHelpers.ChangeValue(estabelecimento.TIPO);
                    Console.Write("Lotação máxima em seu estabelecimento: ");
                    estabelecimento.LOTACAO = ConsoleHelpers.ChangeValue(estabelecimento.LOTACAO);
                    Console.Write("Digite o número de mesas que possuem no seu estabelecimento: ");
                    estabelecimento.QUANTIDADE_MESAS = ConsoleHelpers.ChangeValue(estabelecimento.QUANTIDADE_MESAS);
                    Console.Write("Digite o preço da entrada (se aplicável): ");
                    estabelecimento.PRECO_ENTRADA = ConsoleHelpers.ChangeValue(estabelecimento.PRECO_ENTRADA);
                    Console.Write("Digite o número de vagas de estacionamento do seu estabelecimento (se aplicável): ");
                    estabelecimento.VAGAS_ESTACIONAMENTO = ConsoleHelpers.ChangeValue(estabelecimento.VAGAS_ESTACIONAMENTO);

                    break;
                }
                catch
                {
                    Console.WriteLine("\nVocê digitou algum dado inválido!");
                    Console.Write("Tecle ENTER para cadastrar seu estabelecimento novamente!");
                    Console.ReadLine();
                    estabelecimento = new EstabelecimentoEntity();
                }
            }
            return estabelecimento;
        }

        public void Delete()
        {
            var parameters = new { Id = GetIndex() };
            string sql = "DELETE FROM ESTABELECIMENTO_2 WHERE ID = @ID";
            this.Execute(sql, parameters);
            Console.WriteLine("Produto excluido com sucesso");
            Console.WriteLine("TECLE ENTER PARA RETORNAR");
            Console.ReadLine();
        }
        private int GetIndex()
        {
            Read();
            Console.WriteLine();
            Console.WriteLine("Acima estão listados os estabelecimentos");
            Console.Write("Digite o ID do estabelecimento que você deseja excluir: ");
            return Convert.ToInt32(Console.ReadLine());
        }


        public void Read(bool showPrompot = false)
        {
            Console.Clear();
            IEnumerable<EstabelecimentoEntity> estabelecimentos = GetEstabelecimento();
            foreach (EstabelecimentoEntity estabelecimento in estabelecimentos)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"{estabelecimento.ID} - {estabelecimento.NOME} / {estabelecimento.TIPO}");
                Console.WriteLine($"Endereço: {estabelecimento.ENDERECO}");
                Console.WriteLine($"Lotação máxima: {estabelecimento.LOTACAO} pessoas");
                Console.WriteLine($"Horário de funcionamento: {estabelecimento.HORARIO_FUNCIONAMENTO}");
                Console.WriteLine($"Quantidade de mesas do local: {estabelecimento.QUANTIDADE_MESAS}");
                Console.WriteLine($"Valor da entrada: {estabelecimento.PRECO_ENTRADA}");
                Console.WriteLine($"Vagas de estacionamento: {estabelecimento.VAGAS_ESTACIONAMENTO}");
            }
            if (showPrompot)
            { 
            Console.Write("\nTecle ENTER para voltar ao menu!");
            Console.ReadLine();
            }
        }
        private IEnumerable<EstabelecimentoEntity> GetEstabelecimento()
        {
            string sql = "SELECT * FROM ESTABELECIMENTO_2";
            return this.GetConnection().Query<EstabelecimentoEntity>(sql);
        }
        public void Update()
        {
            try 
            { 
            Console.Clear();
            Console.WriteLine("\nESTABELECIMENTOS CADASTRADOS:");
            Read();
            Console.Write("\nInforme o ID do estabelecimento que deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            EstabelecimentoEntity estabelecimento = PopularUpdate(GetEstabelecimentoById(id));
            string sql = "UPDATE ESTABELECIMENTO_2 SET NOME = @NOME, ENDERECO = @ENDERECO, LOTACAO = @LOTACAO, HORARIO_FUNCIONAMENTO = @HORARIO_FUNCIONAMENTO, VAGAS_ESTACIONAMENTO = @VAGAS_ESTACIONAMENTO, QUANTIDADE_MESAS = @QUANTIDADE_MESAS, PRECO_ENTRADA = @PRECO_ENTRADA, TIPO = @TIPO WHERE ID = @ID";
            this.Execute(sql, estabelecimento);
            }
            catch
            {
                Console.Write("\nTecle ENTER e digite um ID válido!");
                Console.ReadLine();
                Update();
            }
        }
        private EstabelecimentoEntity PopularUpdate(EstabelecimentoEntity estabelecimento)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------ EDITAR ESTABELECIMENTO ------");
                Console.WriteLine();
                Console.Write("\nNome do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.NOME);
                Console.Write("\nEndereço do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.ENDERECO);
                Console.Write("\nHorário de funcionamento do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.HORARIO_FUNCIONAMENTO);
                Console.Write("\nTipo do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.TIPO);
                Console.Write("\nLotação do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.LOTACAO);
                Console.Write("\nQuantidade de mesas do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.QUANTIDADE_MESAS);
                Console.Write("\nPreço de entrada do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.PRECO_ENTRADA);
                Console.Write("\nVagas de estacionamento do Estabelecimento: ");
                ConsoleHelpers.ChangeValue(estabelecimento.VAGAS_ESTACIONAMENTO);

                Console.WriteLine("\nAlterações feitas com sucesso!");
                Console.Write("Tecle ENTER para voltar ao menu.");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Você digitou um valor inválido!");
                Console.WriteLine("Tecle Enter para Editar novamente!");
                Console.ReadLine();
                Update();
            }

            return estabelecimento;
        }
        private EstabelecimentoEntity GetEstabelecimentoById(int id)
        {
            string sql = "SELECT * FROM ESTABELECIMENTO_2 WHERE ID = @ID";
            var parametros = new { ID = id };
            return this.GetConnection().QueryFirst<EstabelecimentoEntity>(sql, parametros);
        }
    }
}
