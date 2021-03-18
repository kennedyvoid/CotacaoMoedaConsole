using CotacaoMoedaConsole.CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoConsole.Entidade
{
    public class DadosCotacao
    {
        public string vlr_cotacao { get; set; }
        public string cod_cotacao { get; set; }
        public string dat_cotacao { get; set; }

        public static List<DadosCotacao> GetDadosCatacao()
        {
            List<DadosCotacao> ListaCotacao = new List<DadosCotacao>();
            MoedaCSV moedaCSV = new MoedaCSV();
            var response = moedaCSV.GetDadosCotacao();
            int i = 0;
            foreach (var item in response)
            {
                string[] vs = item.Split(";");
                if (i > 0)
                {
                    ListaCotacao.Add(new DadosCotacao() { vlr_cotacao = vs[0], cod_cotacao = vs[1], dat_cotacao = vs[2] });
                }
                i++;
            }
            return ListaCotacao;
        }
    }
}
