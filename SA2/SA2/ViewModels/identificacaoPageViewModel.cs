using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;
using SA2.Models;
using SA2.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            if (String.IsNullOrEmpty(Telefone_Celular))
            {
                _pagina.DisplayAlert("Atenção", "Adicione um telefone", "Ok");
                return false;
            }

            if (Telefone_Celular.Length < 11)
            {
                _pagina.DisplayAlert("Atenção", "Telefone invalido", "Ok");
                return false;
            }

            if (SexoSelecionado == null)
            {
                _pagina.DisplayAlert("Atenção", "Informe um sexo", "Ok");
                return false;
            }
            if(Data_Nascimento > DateTime.Now)
            {
                _pagina.DisplayAlert("Atenção!", "Informe uma data correta", "Ok");
                return false;
            }
            
            return true;
        }

        private List<Sexo> _sexo;
        public List<Sexo> Sexos
        {
            get { return _sexo; }
            set { SetProperty<List<Sexo>>(ref _sexo, value); }
        }

        private Sexo sexoselecionado;
        public Sexo SexoSelecionado
        {
            get { return sexoselecionado; }
            set { SetProperty<Sexo>(ref sexoselecionado, value); }
        }



        public ICommand ContinuarCommand { get; }

        public identificacaoPageViewModel(Page pagina, ClienteModels cliente) : base (pagina)
        {
            Cliente = cliente;
            Mensagem = "Queremos lhe conhecer melhor, por favor \n informe os dados nos campos abaixo";
            Nome = "";
            Data_Nascimento = DateTime.Now;        
            Telefone_Celular = "";
            
            ContinuarCommand = new Command(ExecuteContinuarCommand);


            Sexos = new List<Sexo>()
            {
            new Sexo(){ Codigo = 1, Nome = "Feminino" },
            new Sexo(){ Codigo = 2, Nome = "Masculino" },
            
            };
            SexoSelecionado = null;

        }

        private async void ExecuteContinuarCommand()
        {
            Cliente.Nome = Nome;
            Cliente.Data_Nascimento = Data_Nascimento;
            Cliente.Telefone_Celular = Telefone_Celular;
            Cliente.Sexo = SexoSelecionado;

             if (DadosValidosIdentificacao())
             {

            EnderecoPage page = new EnderecoPage(Cliente);
                await _navigation.PushAsync(page);
           }

           else
            {

            }

        }

        public class Sexo
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
        }


    }
}