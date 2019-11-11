using SA2.Models;
using SA2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SA2.ViewModels
{
    public class DocumentosPageViewModel : BaseViewModel
    {

        private string _mensagem;

        public string Mensagem
        {
            get { return _mensagem;}
            set { SetProperty<string>(ref _mensagem, value); }
        }

        private string rg_cnh;

        public string RG_CNH
        {
            get { return rg_cnh; }
            set { SetProperty<string>(ref rg_cnh, value); }
        }

        private string orgao_emssior;

        public string Orgao_Emissor
        {
            get { return orgao_emssior;}
            set { SetProperty<string>(ref orgao_emssior, value); }
        }

        private string _uf;

        public string UF
        {
            get { return _uf;}
            set { SetProperty<string>(ref _uf, value); }
        }

        private DateTime data_emissao;
        
        public DateTime Data_Emissao
        {
            get { return data_emissao; }
            set { SetProperty<DateTime>(ref data_emissao, value); }
        }

        private bool DadosPessoaisValidos()
        {
            if (String.IsNullOrEmpty(RG_CNH))
            {
                _pagina.DisplayAlert("Faltou!", "Informe o RG ou CNH", "Ok");
                return false;
            }

            if (String.IsNullOrEmpty(Orgao_Emissor))
            {
                _pagina.DisplayAlert("Atenção!", "Informe o Orgão Emissor", "Ok");
                return false;

            }
         
            return true;
        }


        public ICommand ContinuarCommand { get; }

        public DocumentosPageViewModel(Page Pagina, ClienteModels cliente) : base(Pagina)
        {
            Cliente = cliente;

            Mensagem = "Informe os seus dados documentais";
            RG_CNH = "";
            Orgao_Emissor = "";
            UF = "";
            Data_Emissao = DateTime.Now;

            ContinuarCommand = new Command(ExecuteContinuarCommand);

        }

        private async void ExecuteContinuarCommand()
        {
            Cliente.RG_CNH = RG_CNH;
            Cliente.Orgao_Emissor = Orgao_Emissor;
            Cliente.UF = UF;
            Cliente.Data_Emissao = Data_Emissao;

            if (DadosPessoaisValidos())
            {
                DadosPessoais page = new DadosPessoais(Cliente);
                await _navigation.PushAsync(page);

            }
            else
            {
                await _pagina.DisplayAlert("Faltou!", "Tais tolo? Implementa ae xtopo!", "Ok");
            }
        }



}
}


    
