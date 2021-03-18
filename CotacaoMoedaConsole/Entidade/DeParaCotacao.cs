using CotacaoMoedaConsole.CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoConsole.Entidade
{
    public class DeParaCotacao
    {
        public string ID_MOEDA { get; set; }
        public string cod_cotacao { get; set; }

        public static List<DeParaCotacao> GetDadosMoedas()
        {
            List<DeParaCotacao> ListaMoedas = new List<DeParaCotacao>();
            MoedaCSV moedaCSV = new MoedaCSV();
            var response = moedaCSV.GetDePara();
            int i = 0;
            foreach (var item in response)
            {
                string[] vs = item.Split(";");
                if (i > 0)
                {
                    ListaMoedas.Add(new DeParaCotacao() { ID_MOEDA = vs[0], cod_cotacao = vs[1] });
                }
                i++;
            }
            return ListaMoedas;
        }
    }
}
