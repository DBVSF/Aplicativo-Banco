using SA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SA2.ViewModels
{
    public class ConcluidoPageViewModel :  BaseViewModel
    {
        private string mensagem;

        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
        }

        public ConcluidoPageViewModel(Page pagina, ClienteModels cliente) : base(pagina)
        {
            Mensagem = "Seu cadastro foi enviado, aguarde!";
            Cliente = cliente;


        }

    }
}