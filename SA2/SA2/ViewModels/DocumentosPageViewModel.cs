using SA2.Models;
using SA2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SA2.ViewModels
{
    public class DocumentosPageViewModel : BaseViewModel
    {
        DateTime datadoDocumento = DateTime.Now.AddYears(-20);
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

        private List<UnidadeFederal> _estados;
        public List<UnidadeFederal> Estados
        {
            get { return _estados; }
            set { SetProperty<List<UnidadeFederal>>(ref _estados, value); }
        }

        private UnidadeFederal estadoSelecionado;
        public UnidadeFederal EstadoSelecionado
        {
            get { return estadoSelecionado; }
            set { SetProperty<UnidadeFederal>(ref estadoSelecionado, value); }
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
            if(Data_Emissao < datadoDocumento)
            {
                _pagina.DisplayAlert("Faltou!", "Renove seu documento", "OK");
                return false;
            }

            if (Data_Emissao > DateTime.Now)
            {
                _pagina.DisplayAlert("Faltou!", "Informe uma data valida!", "Ok");
                return false;
            }
            if(EstadoSelecionado == null)
            {
                _pagina.DisplayAlert("Faltou!", "Informe um Estado Valido!", "Ok");
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
            Data_Emissao = DateTime.Now;

            ContinuarCommand = new Command(ExecuteContinuarCommand);

            Estados = new List<UnidadeFederal>()
            {
            new UnidadeFederal(){ Codigo = "SC", Nome = "Santa Catarina"},
            new UnidadeFederal(){ Codigo = "PR", Nome = "Paraná"},
            new UnidadeFederal(){ Codigo = "RS", Nome = "Rio Grande do Sul"}
            };

            EstadoSelecionado = null;
        }

        private async void ExecuteContinuarCommand()
        {
            Cliente.UF = EstadoSelecionado;
            Cliente.RG_CNH = RG_CNH;
            Cliente.Orgao_Emissor = Orgao_Emissor;
            
            Cliente.Data_Emissao = Data_Emissao;

            if (DadosPessoaisValidos())
            {
            DadosPessoais page = new DadosPessoais(Cliente);
                await _navigation.PushAsync(page);

            }
            else
            {

             }
        }

        public class UnidadeFederal
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }

        }

    }
}


    
