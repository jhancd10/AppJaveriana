using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppJaveriana.Models;
using AppJaveriana.Services.RestAPIClient;
using AppJaveriana.Views;

namespace AppJaveriana.ViewModels
{
    public class ClienteViewModel : UserDetailCredentials
    {
        //Atributos
        public UserDetailCredentials cliente;
        public RestClient servicioJaveriana;
        private MensajeErrorModel mensajeError;


        //Constructores
        public ClienteViewModel()
        {
            cliente = new UserDetailCredentials();
            servicioJaveriana = new RestClient();
            mensajeError = new MensajeErrorModel();
            LoginCommand = new Command(async () => await Login(), () => true);
        }

        //Eventos
        public Command LoginCommand { get; set; }

        //Métodos
        public MensajeErrorModel MensajeError
        {
            get { return mensajeError; }
            set
            {
                mensajeError = value;
                OnPropertyChanged();
            }
        }

        private async Task Login()
        {
            cliente.UserName = UserName;
            cliente.Password = Password;
            MensajeError = await servicioJaveriana.LoginCliente(cliente);
            //var x = await servicioLicorera.getAsignaturas();

            if (MensajeError.HasError == false)
            {
                //Application.Current.MainPage = new NavigationPage(new vistaHorario());
                Application.Current.MainPage = new MainPage(servicioJaveriana);
            }

            //var resp = servicioJaveriana.getAsignaturas();

        }

    }
}