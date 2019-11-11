using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;
using SA2.Models;
using SA2.Views;

namespace SA2.ViewModels
{
    public class identificacaoPageViewModel : BaseViewModel
    {
        DateTime dataNascimentoMinima = DateTime.Now.AddYears(-18);

        DateTime dtnNascimento = new DateTime(1900, 1, 1);

       
        private string mensagem;
        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
        }

 



        private string _nome;
        public string Nome
        {
            
            get { return _nome; }
            set { SetProperty<string>(ref _nome, value); }
        }

        private DateTime _data_Nascimento;
        
        public DateTime Data_Nascimento
        {
            get { return _data_Nascimento; }
            set { SetProperty<DateTime>(ref _data_Nascimento, value); }
        }


       

        private string _sexo;

        public string  Sexo
         {
           get { return _sexo; }
           set { SetProperty<string>(ref _sexo, value);}
         }

        private string _telefone_Celular;

        public string Telefone_Celular
        {
            get { return _telefone_Celular; }
            set { SetProperty<string>(ref _telefone_Celular, value); }
        }


        private bool DadosValidosIdentificacao()
        {
            if (String.IsNullOrEmpty(Nome))
            {
                _pagina.DisplayAlert("Faltou!", "Informe um Nome", "Ok");
                return false;
            }

            if (Data_Nascimento > dataNascimentoMinima )
            {
                _pagina.DisplayAlert("Atenção!", "Você precisa ter 18 anos", "Ok");
                return false;

            }
            if (string.IsNullOrEmpty(Telefone_Celular))
            {
                _pagina.DisplayAlert("Atenção", "Adicione um telefone", "Ok");
                return false;
            }
            if (Telefone_Celular.Length < 11)
            {
                _pagina.DisplayAlert("Atenção", "Telefone invalido", "Ok");
                return false;
            }
            return true;
        }



        public ICommand ContinuarCommand { get; }

        public identificacaoPageViewModel(Page pagina, ClienteModels cliente) : base (pagina)
        {
            Cliente = cliente;
            Mensagem = "Queremos lhe conhecer melhor, por favor \n informe os dados nos campos abaixo";
            Nome = "";
            Data_Nascimento = DateTime.Now;        
            Telefone_Celular = "";
            Sexo = "";
            ContinuarCommand = new Command(ExecuteContinuarCommand);
        }

        private async void ExecuteContinuarCommand()
        {
            Cliente.Nome = Nome;
            Cliente.Data_Nascimento = Data_Nascimento;
            Cliente.Telefone_Celular = Telefone_Celular;
            Cliente.Sexo = Sexo;

            if (DadosValidosIdentificacao())
            {
                
                EnderecoPage page = new EnderecoPage(Cliente);
                await _navigation.PushAsync(page);
            }

            else
            {
                await _pagina.DisplayAlert("Faltou!", "Tais tolo? Implementa ae xtopo!", "Ok");
            }

        }
    }
}