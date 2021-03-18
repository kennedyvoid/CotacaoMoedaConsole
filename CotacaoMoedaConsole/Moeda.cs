using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoMoedaConsole
{
    public class Moeda 
    {
        public Moeda(string moeda, string data_inicio, string data_fim)
        {
            this.moeda = moeda;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
        }
        public Moeda()
        {

        }

        public string moeda { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
    }

}
