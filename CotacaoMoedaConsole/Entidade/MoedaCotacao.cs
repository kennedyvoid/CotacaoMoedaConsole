using CotacaoMoedaConsole.CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoConsole.Entidade
{
    public class MoedaCotacao
    {
        public string ID_MOEDA { get; set; }
        public string DATA_REF { get; set; }
        public string VL_COTACAO { get; set; }

        public static void AddMoedaCotacao(List<MoedaCotacao> moedaCotacao)
        {
            MoedaCSV moedaCSV = new MoedaCSV();

            List<string> Linha = new List<string>();
            foreach (var item in moedaCotacao)
            {
                Linha.Add(item.ID_MOEDA + ";" + DateTime.Parse(item.DATA_REF).ToString("yyyy-MM-dd") + ";" + item.VL_COTACAO);
            }
            moedaCSV.AddFile(Linha);


        }

    }
}
