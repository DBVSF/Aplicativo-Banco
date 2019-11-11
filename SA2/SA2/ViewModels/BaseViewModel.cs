using Android.Runtime;
using SA2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;


namespace SA2.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected ClienteModels Cliente;
        protected bool _isBusy;
        protected INavigation _navigation;
        protected Page _pagina;
        public event PropertyChangedEventHandler PropertyChanged;

        private string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { SetProperty<string>(ref titulo, value); }
        }

        public BaseViewModel(Xamarin.Forms.Page pagina)
        {
            _navigation = pagina.Navigation;
            _pagina = pagina;

            Xamarin.Forms.NavigationPage.SetBackButtonTitle(_pagina, "Voltar");
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

     

}
   

}