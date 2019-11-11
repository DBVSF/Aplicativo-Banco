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
    public class RendaPageViewModel : BaseViewModel
    {

        private string mensagem;
        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
        }

        private double _valor_Renda;
        public double Valor_Renda
        {
            get { return _valor_Renda; }
            set { SetProperty<double>(ref _valor_Renda, value); }
        }

        private double _valor_Limite;
        public double Valor_Limite
        {
            get { return _valor_Limite; }
            set { SetProperty<double>(ref _valor_Limite, value); }
        }

        private DateTime _vencimento_Fatura;
        public DateTime Vencimento_Fatura
        {
            get { return _vencimento_Fatura; }
            set { SetProperty<DateTime>(ref _vencimento_Fatura, value); }
        }

        private bool DadosRendaValida()
        {
            if (Valor_Renda > 0)
            {
                _pagina.DisplayAlert("Faltou!", "Informe uma renda valida", "Ok");
                return false;
            }

            if (Valor_Limite > 0)
            {
                _pagina.DisplayAlert("Faltou!", "Informe um limite valido", "Ok");
                return false;
            }
            return true;

        }


        public ICommand ContinuarCommand { get; }

        public RendaPageViewModel(Page pagina, ClienteModels cliente) : base(pagina)
        {
            Cliente = cliente;
            Mensagem = "Informe seus dados financeiros";
            Valor_Renda = 0;
            Valor_Limite= 0;
            Vencimento_Fatura = DateTime.Now;

            ContinuarCommand = new Command(ExecuteContinuarCommand);
        }

        private async void ExecuteContinuarCommand()
        {
            Cliente.Valor_Limite = Valor_Limite;
            Cliente.Valor_Renda = Valor_Renda;
            Cliente.Vencimento_Fatura = Vencimento_Fatura;

            if (DadosRendaValida())
            {
                BiometriaPage page = new BiometriaPage(Cliente);
                await _navigation.PushAsync(page);
            }
            else
            {         
           
            }

         
        }
    }


}
