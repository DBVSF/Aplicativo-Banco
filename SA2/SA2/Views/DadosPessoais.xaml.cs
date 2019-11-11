using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA2.Models;
using SA2.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SA2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DadosPessoais : ContentPage
    {
        public DadosPessoais(ClienteModels cliente)
        {
            InitializeComponent();
            BindingContext = new DadosPessoaisPageViewModel(this, cliente);

        }
    }
}