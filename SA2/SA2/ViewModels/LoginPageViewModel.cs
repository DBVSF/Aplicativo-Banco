using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SA2.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
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
            Cpf = "";
            Senha = "";
            LogarCommand = new Command(ExecuteLogarCommand);
        }

        private async void ExecuteLogarCommand()
        {
          
        }
    }
}
