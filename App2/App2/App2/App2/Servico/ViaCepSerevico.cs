using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using App2.Servico.Modelo;
using Newtonsoft.Json;

namespace App2.Servico
{
    public class ViaCepSerevico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
