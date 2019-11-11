using SA2.Models;
using SA2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using Plugin.Media;

namespace SA2.ViewModels
{
    public class BiometriaPageViewModel : BaseViewModel
    {
        private string mensagem;
        public string Mensagem
        {
            get { return mensagem; }
            set { SetProperty<string>(ref mensagem, value); }
        }

        private ImageSource _selfie;
        public ImageSource Selfie
        {
            get { return _selfie; }
            set { SetProperty<ImageSource>(ref _selfie,  value); }
        }

        private ImageSource _rg_cnh;
        public ImageSource RG_CNH
        {
            get { return _rg_cnh; }
            set { SetProperty<ImageSource>(ref _rg_cnh, value); }
        }

        private ImageSource _residencia;
        public ImageSource Residencia
        {
            get { return _residencia; }
            set { SetProperty<ImageSource>(ref _residencia, value); }
        }


        private ImageSource _renda;
        public ImageSource Renda
        {
            get { return _renda; }
            set { SetProperty<ImageSource>(ref _renda, value); }
        }

       
        public ICommand ContinuarCommand { get; }


        public BiometriaPageViewModel(Page pagina, ClienteModels cliente) : base(pagina)
        {
            Cliente = cliente;
            Mensagem = "Vamos digitalizar seus documentos";
            Selfie = "";
            RG_CNH = "";
            Residencia = "";
            Renda = "";
         
            ContinuarCommand = new Command(ExecuteContinuarCommand);
        }

        private async void ExecuteRendaCommand()
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                Renda = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        private async void ExecuteResidenciaCommand()
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                Residencia = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        private async void ExecuteRG_CNHCommand()
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                RG_CNH = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

   
  

        private async void ExecuteContinuarCommand()
        {
            Cliente.Selfie = Selfie;

            ConcluidoPage page = new ConcluidoPage(Cliente);
            await _navigation.PushAsync(page);
        }

    }
}