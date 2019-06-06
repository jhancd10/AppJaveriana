using AppJaveriana.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppJaveriana.Services.RestAPIClient
{
    public class RestClient
    {
        private readonly HttpClient client;
        private MensajeErrorModel mensajeError;
        private UserDetailCredentials user;
        private Asignatura[] asignaturaUser;
        private DiaAsignatura diasAsignaturas;
        private const string LoginWebServiceUrl = "http://replica.javerianacali.edu.co:8100/WSMobile/mobile/v2/Autenticacion/?usu=";

        // Constructor
        public RestClient()
        {
            client = new HttpClient();
            mensajeError = new MensajeErrorModel();
            user = null;
            asignaturaUser = null;
            diasAsignaturas = null;
        }

        #region Getter/Setters
        public MensajeErrorModel MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }

        public UserDetailCredentials Usuario
        {
            get { return user; }
            set { user = value; }
        }

        public Asignatura[] AsignaturaUser
        {
            get { return asignaturaUser; }
        }

        public DiaAsignatura DiasAsignaturas
        {
            get { return diasAsignaturas; }
            set { diasAsignaturas = value; }
        }

        #endregion
        public async Task<MensajeErrorModel> LoginCliente(UserDetailCredentials cliente)
        {
            try
            {
                var content = await client.GetStringAsync(LoginWebServiceUrl + cliente.UserName + "&" + "pass=" + cliente.Password);
                //UserDetailCredentials loginCliente = JsonConvert.DeserializeObject<UserDetailCredentials>(content);
                user = JsonConvert.DeserializeObject<UserDetailCredentials>(content);

                if (user.IsValido)
                {
                    mensajeError.Message = "Exitoso";
                    mensajeError.HasError = false;
                    await GetAsignaturas();
                }

                else
                {
                    mensajeError.Message = "Credenciales no Validas";
                    mensajeError.HasError = true;
                }
            }

            catch (HttpRequestException e)
            {
                mensajeError.Message = "Error de comunicación";
                mensajeError.HasError = true;
            }

            return mensajeError;
        }

        public async Task<Asignatura[]> GetAsignaturas()
        {
            string contentAsign = "";

            var url = "http://replica.javerianacali.edu.co:8100/WSMobile/mobile/v2/asignaturas";
            client.DefaultRequestHeaders.Add("x-t6519fdd1s5q", user.Token); ;
            contentAsign = await client.GetStringAsync(url);
            //UserDetailCredentials asignaturas = JsonConvert.DeserializeObject<UserDetailCredentials>(contentAsign);
            asignaturaUser = JsonConvert.DeserializeObject<Asignatura[]>(contentAsign);
            
            return asignaturaUser;
        }

    }
}
