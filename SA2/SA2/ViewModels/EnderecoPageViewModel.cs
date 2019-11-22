
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using SA2.Views;
using SA2.Models;
using System.Runtime.CompilerServices;

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

        //picker cidade
      
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
                _pagina.DisplayAlert("Atenção!", "Informe um numero valido", "Ok");
                return false;
            }
            if(CidadeSelecionada == null)
            {
                _pagina.DisplayAlert("Atençao", "Informe uma Cidade", "ok");
                return false;
            }
            if (EstadoSelecionado == null)
            {
                _pagina.DisplayAlert("Atençao", "Informe um Estado", "ok");
                return false;
            }

            return true;
        }
         

        public ICommand ContinuarCommand { get; }

        public EnderecoPageViewModel(Page pagina, ClienteModels cliente) : base(pagina)
        {
            Cliente = cliente;

            Mensagem = "Informe seu endereço, isso nos  \n ajudará na análise de crédito";      
            
            CEP = "";
            LograDouro = "";
            Bairro = "";         
            NumeroCasa = "";
            Complemento = "";
            ContinuarCommand = new Command(ExecuteContinuarCommand);

            Cidades = new List<Cidade>()
            {
            new Cidade(){ Codigo = 1, Nome = "Brusque"},
            new Cidade(){ Codigo = 2, Nome = "Curitiba"},
            new Cidade(){ Codigo = 3, Nome = "Porto Alegre"},
            
            };

            Estados = new List<Estado>()
            {
            new Estado(){ Codigo = "SC", Nome = "Santa Catarina"},
            new Estado(){ Codigo = "PR", Nome = "Paraná"},
            new Estado(){ Codigo = "RS", Nome = "Rio Grande do Sul"}
            };

            EstadoSelecionado = null;
            CidadeSelecionada = null;
         

        }


        private List<Cidade> _cidades;
        public List<Cidade> Cidades
        {
            get { return _cidades; }
            set { SetProperty<List<Cidade>>(ref _cidades, value); }
        }

        private Cidade cidadeSelecionada;
        public Cidade CidadeSelecionada
        {
            get { return cidadeSelecionada; }
            set { SetProperty<Cidade>(ref cidadeSelecionada, value); }
        }

        private List<Estado> _estados;
        public List<Estado> Estados
        {
            get { return _estados; }
            set { SetProperty<List<Estado>>(ref _estados, value); }
        }

        private Estado estadoSelecionado;
        public Estado EstadoSelecionado
        {
            get { return estadoSelecionado; }
            set { SetProperty<Estado>(ref estadoSelecionado, value); }
        }


        private async void ExecuteContinuarCommand()
        {
            Cliente.Cidade = CidadeSelecionada;
            Cliente.CEP = CEP;
            Cliente.LograDouro = LograDouro;
            Cliente.Bairro = Bairro;
            Cliente.Estado = EstadoSelecionado;
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

        public class Cidade
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }

        }

        public class Estado
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }

        }





    }

}


 