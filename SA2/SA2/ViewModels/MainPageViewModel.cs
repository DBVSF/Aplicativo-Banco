using SA2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SA2.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string mensagem;
        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
        }

        public ICommand EntrarCommand { get; }
        public ICommand CadastrarCommand { get; }

        public MainPageViewModel(Page pagina) : base(pagina)
        {
            Mensagem = "Bem Vindo!";

            EntrarCommand = new Command(ExecuteEntrarCommand);
            CadastrarCommand = new Command(ExecuteCadastrarCommand);
        }

        private async void ExecuteEntrarCommand()
        {
            LoginPage page = new LoginPage();
            await _navigation.PushAsync(page);
           
        }

        private async void ExecuteCadastrarCommand()
        {
            CadastroUsuarioPage page = new CadastroUsuarioPage();
            await _navigation.PushAsync(page);
        }
    }
}
