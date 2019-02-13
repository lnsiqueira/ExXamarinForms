using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_consultarCep_Highcon.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_consultarCep_Highcon.Servico.Modelo
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViaCEP(string cep)
        {
            string novoEnderecoRL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            //sincrono -- trava
            string conteudo = wc.DownloadString(novoEnderecoRL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end;


        }
    }
}
