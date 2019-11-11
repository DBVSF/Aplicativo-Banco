using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;
using SA2.Views;
using SA2.Models;

namespace SA2.ViewModels
{
    public class EnderecoPageViewModel : BaseViewModel
    {

        private string mensagem;
        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
        }

        private string _cep;

        public string CEP
        {
            get { return _cep; }
            set { SetProperty<string>(ref _cep, value); }
        }


        private string _logradouro;

        public string LograDouro
        {
            get { return _logradouro; }
            set { SetProperty<string>(ref _logradouro, value); }
        }

        private string _bairro;

        public string Bairro
        {
            get { return _bairro; }
            set { SetProperty<string>(ref _bairro, value); }
        }

        private string _cidade;

        public string Cidade
        {
            get { return _cidade; }
            set { SetProperty<string>(ref _cidade, value); }
        }

        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { SetProperty<string>(ref _estado, value); }

        }

        private string _numero_casa;

        public string NumeroCasa
        {
            get { return _numero_casa; }
            set { SetProperty<string>(ref _numero_casa, value); }
        }

        private string _complemento;

        public string Complemento
        {
            get { return _complemento; }
            set { SetProperty<string>(ref _complemento, value); }
        }

        private bool DadosValidosEndereco()
        {
           

            
            if (String.IsNullOrEmpty(CEP))
            {
                _pagina.DisplayAlert("Faltou!", "Informe um CEP", "Ok");
                return false;
            }

            if (String.IsNullOrEmpty(LograDouro))
            {
                _pagina.DisplayAlert("Atenção!", "Informe um Logradouro valido", "Ok");
                return false;

            }

            if (String.IsNullOrEmpty(Bairro))
            {
                _pagina.DisplayAlert("Atenção!", "Informe um Bairro valido", "Ok");
                return false;

            }
           
           
            if (String.IsNullOrEmpty(NumeroCasa))
            {
                _pagina.DisplayAlert("Atenção!", "Informe um Numero valido", "Ok");
                return false;
            }
            return true;
        }
         

        public ICommand ContinuarCommand { get; }

        public EnderecoPageViewModel(Page pagina, ClienteModels cliente) : base(pagina)
        {
            Cliente = cliente;

            Mensagem = "Informe seu endereço, isso nos  \n ajudará na análise de crédito";
            Cidade = "";
            CEP = "";
            LograDouro = "";
            Bairro = "";
            Estado = "";
            NumeroCasa = "";
            Complemento = "";
            ContinuarCommand = new Command(ExecuteContinuarCommand);
        }

    private async void ExecuteContinuarCommand()
        {
            Cliente.Cidade = Cidade;
            Cliente.CEP = CEP;
            Cliente.LograDouro = LograDouro;
            Cliente.Bairro = Bairro;
            Cliente.Estado = Estado;
            Cliente.NumeroCasa = NumeroCasa;
            Cliente.Complemento = Complemento;

            if (DadosValidosEndereco())
            {
                Documentos page = new Documentos(Cliente);
                await _navigation.PushAsync(page);
            }
            else
            {
              
            }
            
        }

}

}
 