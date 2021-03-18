using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CotacaoMoedaConsole.CSV
{
    public class MoedaCSV
    {
        private static string folder;
        public MoedaCSV()
        {
            var PathBin = Directory.GetCurrentDirectory();
            if (PathBin.Contains("bin"))
            {
                var PathRaiz = PathBin.Split("bin");
                folder = PathRaiz[0] + "CSV";
            }
            else
            {
                folder = PathBin;
            }

        }
        public List<string> GetDadosCotacao()
        {
            List<string> Response = new List<string>();

            var Arquivo = File.ReadAllLines(folder + "\\DadosCotacao.csv");
            foreach (var item in Arquivo)
            {
                Response.Add(item);
            }
            return Response;
        }
        public List<string> GetDadosMoeda()
        {
            List<string> Response = new List<string>();

            var Arquivo = File.ReadAllLines(folder + "\\DadosMoeda.csv");
            foreach (var item in Arquivo)
            {
                Response.Add(item);
            }
            return Response;
        }
        public List<string> GetDePara()
        {
            List<string> Response = new List<string>();

            var Arquivo = File.ReadAllLines(folder + "\\De-Para.csv");
            foreach (var item in Arquivo)
            {
                Response.Add(item);
            }
            return Response;
        }

        public string CriarFileAsync()
        {
            string nome = "Resultado_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            File.Create(Path.Combine(folder, nome + ".csv")).Dispose();
            return nome;
        }

        public void AddFile(List<string> linhas)
        {
            string nome = "Resultado_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            File.Create(Path.Combine(folder, nome + ".csv")).Dispose();

            List<string> file = new List<string>();
            var Arquivo = File.ReadAllLines(Path.Combine(folder, nome + ".csv"));
            foreach (var item in Arquivo)
            {
                file.Add(item);
            }
            foreach (var linha in linhas)
            {
                file.Add(linha);
            }

             File.WriteAllLines(Path.Combine(folder, nome + ".csv"), file.Take(file.Count + 1));

        }


    }
}
