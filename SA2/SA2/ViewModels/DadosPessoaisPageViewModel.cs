using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;
using SA2.Views;
using SA2.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SA2.ViewModels
{
    public class DadosPessoaisPageViewModel : BaseViewModel
    {

        private string mensagem;

        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty<string>(ref _email, value); }
        }

        private string _confirmacaoEmail;
        public string ConfirmacaoEmail
        {
            get { return _confirmacaoEmail; }
            set { SetProperty<string>(ref _confirmacaoEmail, value); }
        }

        private string _nome_Mae;
        public string Nome_Mae
        {
            get { return _nome_Mae; }
            set { SetProperty<string>(ref _nome_Mae, value); }
        }



        private List<Estado_Civil> _estadosC;
        public List<Estado_Civil> EstadoCivil
        {
            get { return _estadosC; }
            set { SetProperty<List<Estado_Civil>>(ref _estadosC, value); }
        }

        private Estado_Civil estadocSelecionada;
        public Estado_Civil EstadoCivilSelecionado
        {
            get { return estadocSelecionada; }
            set { SetProperty<Estado_Civil>(ref estadocSelecionada, value); }
        }


        private List<Profissao> _profissoes;
        public List<Profissao> Profissoes
        {
            get { return _profissoes; }
            set { SetProperty<List<Profissao>>(ref _profissoes, value); }
        }

        private Profissao profissaoselecionada;
        public Profissao ProfissaoSelecionada
        {
            get { return profissaoselecionada; }
            set { SetProperty<Profissao>(ref profissaoselecionada, value); }
        }


        private List<Escolaridade> _escolaridade;
        public List<Escolaridade> Escolaridades
        {
            get { return _escolaridade; }
            set { SetProperty<List<Escolaridade>>(ref _escolaridade, value); }
        }

        private Escolaridade escolaridadeselecionada;
        public Escolaridade EscolaridadeSelecionada
        {
            get { return escolaridadeselecionada; }
            set { SetProperty<Escolaridade>(ref escolaridadeselecionada, value); }
        }



        private bool DadosPessoaisValidos()
        {
            if (String.IsNullOrEmpty(Email))
            {
                _pagina.DisplayAlert("Faltou!", "Informe um Email Valido", "Ok");
                return false;
            }

            if (String.IsNullOrEmpty(Nome_Mae))
            {
                _pagina.DisplayAlert("Atenção!", "Informe o nome de sua Mãe", "Ok");
                return false;

            }
            if (!Email.Contains("@"))
            {
                _pagina.DisplayAlert("Atenção", "O Email precisa conter @ ", "Ok");
                return false;
            }
            if (EscolaridadeSelecionada == null)
            {
                _pagina.DisplayAlert("Atenção", "Selecione uma Escolaridade", "ok");
            return false;
            }
            if (EstadoCivilSelecionado == null)
            {
            _pagina.DisplayAlert("Atenção", "Selecione um Estado Civil", "ok");
            return false;
            }
            if (ProfissaoSelecionada == null)
             {
            _pagina.DisplayAlert("Atenção", "Selecione uma Profissao", "ok");
            return false;
            }
            return true;
        }

       
     

        public ICommand ContinuarCommand { get; }

        public DadosPessoaisPageViewModel(Page Pagina, ClienteModels cliente) : base(Pagina)
        {
            Cliente = cliente;
            Mensagem = "Informe os seus dados pessoais";
            Email = "";
            ConfirmacaoEmail = "";
            Nome_Mae = "";

            ContinuarCommand = new Command(ExecuteContinuarCommand);

            Profissoes = new List<Profissao>()
            {
                new Profissao(){Codigo = 1, Nome = "Professor"},
                new Profissao(){Codigo = 2, Nome = "Programador"},
                new Profissao(){Codigo = 3, Nome = "Agiota"},
            };

                        Escolaridades = new List<Escolaridade>()
            {
                new Escolaridade(){Codigo = 1, Nome = "Ensino Fundamental Completo"},
                new Escolaridade(){Codigo = 2, Nome = "Ensino Médio Completo"},
                new Escolaridade(){Codigo = 3, Nome = "Ensino Superior Completo"},
            };

                        EstadoCivil = new List<Estado_Civil>()
            {
                new Estado_Civil(){Codigo = 1, Nome = " Casado "},
                new Estado_Civil(){Codigo = 2, Nome = " Solteiro "},                
            };



                        ProfissaoSelecionada = null;
                        EscolaridadeSelecionada = null;
                        EstadoCivilSelecionado = null;
        }

        private async void ExecuteContinuarCommand()
        {
            Cliente.Email = Email;
            Cliente.ConfirmacaoEmail = ConfirmacaoEmail;
            Cliente.Nome_Mae = Nome_Mae;
            Cliente.Profissao = ProfissaoSelecionada;
            Cliente.Escolaridade = EscolaridadeSelecionada;
            Cliente.Estado_Civil = EstadoCivilSelecionado;

           if (DadosPessoaisValidos()){
                RendaPage page = new RendaPage(Cliente);
                await _navigation.PushAsync(page);

            }
            else
            {
              
           }

            
            
        }


        public class Profissao
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
        }

        public class Escolaridade
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
        }

        public class Estado_Civil
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
        }


    }


}