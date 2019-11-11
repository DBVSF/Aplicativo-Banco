using SA2.Models;
using SA2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SA2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroUsuarioPage : ContentPage
	{
   
		public CadastroUsuarioPage ()
		{
			InitializeComponent ();
            BindingContext = new CadastroUsuarioPageViewModel(this);
        
		}
	}
}