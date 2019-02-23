using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;
namespace App01_ConsultarCEP
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
            //TODO Logica do programa

           
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {3}, {2}, {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                    DisplayAlert("erro!", "o endereço não foi encontrado com o CEP: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO Critico", e.Message, "OK");

                }
                
            }
        }

        //TODO Validações

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                //error
                DisplayAlert("Erro!", "CEP invalído! CEP deve conter somente números", "OK");
                valido = false;
            }
            else if (cep.Length != 8)
            {
                //error
                DisplayAlert("Erro!", "CEP invalído! CEP diferente de 8 caracteres", "OK");
                valido = false;
            }



            return valido;
        }

    }

}
