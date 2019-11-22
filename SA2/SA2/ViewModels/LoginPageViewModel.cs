using SA2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SA2.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {



        private string _mensagem;
        public string Mensagem
        {
            get { return _mensagem; }
            set { SetProperty<string>(ref _mensagem, value); }
        }


        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty<string>(ref _cpf, value); }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { SetProperty<string>(ref _senha, value); }
        }



        public ICommand LogarCommand { get; }

        public LoginPageViewModel(Page pagina) : base(pagina)
        {
            Mensagem = "Insira seus dados";
            Cpf = "";
            Senha = "";
            LogarCommand = new Command(ExecuteLogarCommand);
        }

        private async void ExecuteLogarCommand()
        {
            ConcluidoPage page = new ConcluidoPage(Cliente);
            await _navigation.PushAsync(page);
        }
    }
}
