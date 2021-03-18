using CotacaoConsole.Entidade;
using CotacaoMoedaConsole.CSV;
using CotacaoMoedaConsole.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CotacaoMoedaConsole.Service
{
    public static class MoedaService
    {
        public static List<DadosMoeda> GetDadosMoedas(Moeda moeda)
        {
            var moedasIni = DadosMoeda.GetDadosMoedas().Where(m => DateTime.Parse(m.DATA_REF) > DateTime.Parse(moeda.data_inicio)).ToList();
            var MoedaPData = moedasIni.Where(m => DateTime.Parse(m.DATA_REF) < DateTime.Parse(moeda.data_fim)).ToList();
            var Moeda = MoedaPData.Where(m => m.ID_MOEDA == moeda.moeda).ToList();

            return Moeda;
        }
        public static void CriarMoedaCotacao(Moeda moeda)
        {
            var Moedas = GetDadosMoedas(moeda);
            var DePara = DeParaCotacao.GetDadosMoedas().Where(m => m.ID_MOEDA == moeda.moeda).FirstOrDefault();
            var Cotacao = DadosCotacao.GetDadosCatacao().Where(m => m.cod_cotacao == DePara.cod_cotacao).ToList()
                .Where(t => DateTime.Parse(t.dat_cotacao) > DateTime.Parse(moeda.data_inicio)).ToList()
                .Where(t => DateTime.Parse(t.dat_cotacao) < DateTime.Parse(moeda.data_fim)).ToList();

            List<MoedaCotacao> moedaCotacao = new List<MoedaCotacao>();
            foreach (var item in Moedas)
            {
                moedaCotacao.Add(new MoedaCotacao() { ID_MOEDA = item.ID_MOEDA, DATA_REF = item.DATA_REF });
            }

            var query = from moed in moedaCotacao
                        join cot in Cotacao on DateTime.Parse(moed.DATA_REF) equals DateTime.Parse(cot.dat_cotacao)
                        select new { id = moed.ID_MOEDA, dt = moed.DATA_REF, vl = cot.vlr_cotacao };

            List<MoedaCotacao> request = new List<MoedaCotacao>();

            foreach (var item in query) 
            {
                request.Add(new MoedaCotacao() { ID_MOEDA = item.id, DATA_REF = item.dt, VL_COTACAO = item.vl});
            }
            MoedaCotacao.AddMoedaCotacao(request);

        }

        public static string teste()
        {
            //MoedaCotacao.AddMoedaCotacao();
            //var y = DadosCotacao.GetDadosCatacao();
            //var x = DadosMoeda.GetDadosMoedas(); 
            return "";
        }
    }
}
