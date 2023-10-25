using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPNIGHT.Entity
{
    public class EstabelecimentoEntity
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string ENDERECO { get; set; }
        public string HORARIO_FUNCIONAMENTO { get; set; }
        public string TIPO { get; set; }
        public int LOTACAO { get; set; }
        public int QUANTIDADE_MESAS { get; set; }
        public decimal PRECO_ENTRADA { get; set; }
        public int VAGAS_ESTACIONAMENTO { get; set; }
    }
}


