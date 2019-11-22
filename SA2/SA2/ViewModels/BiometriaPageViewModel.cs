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
using DocumentFormat.OpenXml.Bibliography;

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

        public bool ImagensValidas()
        {
            if (Selfie == null)
            {
                _pagina.DisplayAlert("Faltou", "Você precisa tirar uma foto", "ok");
                return false;
            }
            if (Renda == null)
            {
                _pagina.DisplayAlert("Faltou", "Você precisa tirar uma foto do comprovante de renda", "ok");
                return false;
            }
            if (Residencia == null)
            {
                _pagina.DisplayAlert("Faltou", "Você precisa tirar uma foto do comprovante de residência", "ok");
                return false;
            }
            if (RG_CNH == null)
            {
                _pagina.DisplayAlert("Faltou", "Você precisa tirar uma foto do seu RG ou CNH", "ok");
                return false;
            }
            return true;
        }



        public ICommand ContinuarCommand { get; }
        public ICommand SelfieCommand { get; }
        public ICommand RendaCommand { get; }
        public ICommand ResidenciaCommand { get; }
        public ICommand RgCnhCommand { get; }



        public BiometriaPageViewModel(Page pagina, ClienteModels cliente) : base(pagina)
        {
            Cliente = cliente;
            Mensagem = "Vamos digitalizar seus documentos";
            Selfie = null;
            RG_CNH = null;
            Residencia = null;
            Renda = null;

            ContinuarCommand = new Command(ExecuteContinuarCommand);
            SelfieCommand = new Command(ExecuteSelfieCommand);
            RendaCommand = new Command(ExecuteRendaCommand);
            ResidenciaCommand = new Command(ExecuteResidenciaCommand);
            RgCnhCommand = new Command(ExecuteRG_CNHCommand);
            ContinuarCommand = new Command(ExecuteContinuarCommand);
        }

        private async void ExecuteSelfieCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _pagina.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await _pagina.DisplayAlert("File Location", file.Path, "OK");

            Selfie = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void ExecuteRendaCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _pagina.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await _pagina.DisplayAlert("File Location", file.Path, "OK");

            Renda = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void ExecuteResidenciaCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _pagina.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await _pagina.DisplayAlert("File Location", file.Path, "OK");

            Residencia = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void ExecuteRG_CNHCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _pagina.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await _pagina.DisplayAlert("File Location", file.Path, "OK");

            RG_CNH = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void ExecuteContinuarCommand()
        {
           
            Cliente.Selfie = Selfie;
            Cliente.RG_CNH_FT = RG_CNH;
            Cliente.Residencia_FT = Residencia;
            Cliente.Renda = Renda;

            if (ImagensValidas())
            {
                ConcluidoPage page = new ConcluidoPage(Cliente);
                await _navigation.PushAsync(page);
            }
            else
            {

            }

        }        
    }
}