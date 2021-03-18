using CotacaoMoedaConsole.CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoMoedaConsole.Entidade
{
    public class DadosMoeda
    {
        public string ID_MOEDA { get; set; }
        public string DATA_REF { get; set; }

        public static List<DadosMoeda> GetDadosMoedas()
        {
            List<DadosMoeda> ListaMoedas = new List<DadosMoeda>();
            MoedaCSV moedaCSV = new MoedaCSV();
            var response = moedaCSV.GetDadosMoeda();
            int i = 0;
            foreach (var item in response)
            {
                string[] vs = item.Split(";");
                if (i > 0)
                {
                    ListaMoedas.Add(new DadosMoeda() { ID_MOEDA = vs[0], DATA_REF = vs[1] });
                }
                i++;
            }
            return ListaMoedas;
        }
    }
}
