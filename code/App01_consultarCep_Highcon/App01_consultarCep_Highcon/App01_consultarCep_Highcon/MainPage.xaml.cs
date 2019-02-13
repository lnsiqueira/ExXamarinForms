using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_consultarCep_Highcon.Servico.Modelo;
using App01_consultarCep_Highcon.Servico;

namespace App01_consultarCep_Highcon
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {


            //TODO - Validações

            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscaEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        //Exibir
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP nao encontrado: " +cep, "OK");
                    }
                }

                  
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
              
            }          
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                //ERRO
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres. ", "OK");
                valido = false;
            }

            int novoCEP = 0;
            if(!int.TryParse(cep, out novoCEP))
            {
                //ERRO
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas com números. ", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
