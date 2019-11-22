using SA2.Models;
using SA2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SA2.ViewModels


{
    public class CadastroUsuarioPageViewModel : BaseViewModel
    {
      

        private string mensagem;

        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
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


        private string _confirmacaoSenha;
        public string ConfirmacaoSenha
        {
            get { return _confirmacaoSenha; }
            set { SetProperty<string>(ref _confirmacaoSenha, value); }
        }

      
        private bool DadosValidos()
        {

           
            if (String.IsNullOrEmpty(Cpf))
            {
                _pagina.DisplayAlert("Faltou!", "Informe um cpf", "Ok");
                return false;
                
            }

            if (String.IsNullOrEmpty(Senha))
            {
                _pagina.DisplayAlert("Atenção!", "Você precisa informar uma senha", "Ok");
                return false;

            }
            if(Senha.Length < 4)
            {
                _pagina.DisplayAlert("Atenção", "Senha deve ter 4 Numeros", "Ok");
                return false;
            }
            if ( Senha != ConfirmacaoSenha)
            {
                _pagina.DisplayAlert("Atenção", "As senhas precisam ser iguais", "Ok");
                return false;
            }

            return true;
            

        }

 
        public ICommand CadastrarCommand { get; }
        


        public CadastroUsuarioPageViewModel(Page pagina) : base(pagina)
        {

            Mensagem = "Informe seu CPF e crie uma senha";
            Cpf = "";
            Senha = "";
            ConfirmacaoSenha = "";
            CadastrarCommand = new Command(ExecuteCadastrarCommand);
            
        }


        private async void ExecuteCadastrarCommand()
        {
            ClienteModels cliente = new ClienteModels();
            cliente.CPF = Cpf;
            cliente.Senha = Senha;
            cliente.ConfirmacaoSenha = ConfirmacaoSenha;

           if (DadosValidos())
            {
                
                identificacaoPage page = new identificacaoPage(cliente);
                await _navigation.PushAsync(page);            
            }

            else
            {
                    
            }

        }
}
}