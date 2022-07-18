using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WhosAppMVCfront.Models;

namespace WhosAppMVCfront.Servicios
{
    public class ConsumirApiService : IConsumirApiService
    {



        private readonly ILogger _log;

        //Recibo la clase http client para hacer la peticion
        private HttpClient _httpclient;
        public ConsumirApiService(ILogger<ConsumirApiService> logger)
        {
            _log = logger;
        }
        public async Task<UsuarioVM> CrearUsuario(UsuarioVM user)
        {
            try
            {


                _httpclient = new HttpClient();
                _httpclient.BaseAddress = new Uri("https://localhost:5001/api/User/RegisterUser");
                string contentType = "application/json";

                _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                HttpResponseMessage response;
                var _method = new HttpMethod("POST");
                string myObjectAsJSON = JsonConvert.SerializeObject(user);

                HttpContent _body = new StringContent(myObjectAsJSON);
                _body.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                var uri = _httpclient.BaseAddress;
                response = await _httpclient.PostAsync(uri, _body);
                UsuarioVM resultado = null;
                if (response.IsSuccessStatusCode)
                {
                    string responseContentstring = await _body.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<UsuarioVM>(responseContentstring);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _log.LogInformation("Ocurrio un error en la peticion de registro de usuario" + ex.Message);
                throw;
            }
        }

        public async Task<UsuarioVM> IniciarSesion(UsuarioVM a)
        {
            try
            {


                _httpclient = new HttpClient();
                _httpclient.BaseAddress = new Uri("https://localhost:5001/api/User/Login");
                string contentType = "application/json";

                _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                HttpResponseMessage response;
                var _method = new HttpMethod("POST");
                string myObjectAsJSON = JsonConvert.SerializeObject(a);

                HttpContent _body = new StringContent(myObjectAsJSON);
                _body.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var uri = _httpclient.BaseAddress;
                response = await _httpclient.PostAsync(uri, _body);
                UsuarioVM resultado = null;
                if (response.IsSuccessStatusCode)
                {
                    string responseContentstring = await _body.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<UsuarioVM>(responseContentstring);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _log.LogInformation("Ocurrio un error en la peticion de inicio de sesion" + ex.Message);
                throw;
            }

        }


    }

}

