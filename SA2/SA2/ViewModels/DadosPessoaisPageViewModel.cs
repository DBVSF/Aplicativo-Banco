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

        private string _profissao;
        public string Profissao
        {
            get { return _profissao; }
            set { SetProperty<string>(ref _profissao, value); }
        }

        private string _escolaridade;
        public string Escolaridade
        {
            get { return _escolaridade; }
            set { SetProperty<string>(ref _escolaridade, value); }
        }

        private string _estado_Civil;
        public string Estado_Civil
        {
            get { return _estado_Civil; }
            set { SetProperty<string>(ref _estado_Civil, value); }
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
            Profissao = "";
            Escolaridade = "";
            Estado_Civil = "";

            ContinuarCommand = new Command(ExecuteContinuarCommand);

        }

        private async void ExecuteContinuarCommand()
        {
            Cliente.Email = Email;
            Cliente.ConfirmacaoEmail = ConfirmacaoEmail;
            Cliente.Nome_Mae = Nome_Mae;
            Cliente.Profissao = Profissao;
            Cliente.Escolaridade = Escolaridade;
            Cliente.Estado_Civil = Estado_Civil;

            if (DadosPessoaisValidos()){
                RendaPage page = new RendaPage(Cliente);
                await _navigation.PushAsync(page);

            }
            else
            {
                await _pagina.DisplayAlert("Faltou!", "Tais tolo? Implementa ae xtopo!", "Ok");
            }

            
            
        }



    }
}