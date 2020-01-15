using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CDS_API
{
    class Program
    {
        private static Cidade cidade = new Cidade();
        private static string api = "http://viacep.com.br/ws/";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Digite o CEP da Cidade: ");
                string buscar = Console.ReadLine();
                cidade = getInfo(buscar);
                if (cidade != null)
                {
                    Console.WriteLine("CEP: " + cidade.cep);
                    Console.WriteLine("Cidade: " + cidade.localidade);
                    Console.WriteLine("Estado: " + cidade.uf);
                }
                else
                {
                    Console.WriteLine("CEP Errado.");
                }

            }
        }

        public static Cidade getInfo(String cep)
        {
            try
            {
                WebClient wc = new WebClient();
                String resultado = wc.DownloadString(api + cep + "/json/");
                Cidade aux = JsonSerializer.Deserialize<Cidade>(resultado);
                return aux;
            }
            catch (WebException e)
            {
                return null;
            }
        }
    }
}
