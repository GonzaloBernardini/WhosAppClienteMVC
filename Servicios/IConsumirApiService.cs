using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhosAppMVCfront.Models;

namespace WhosAppMVCfront.Servicios
{
    public interface IConsumirApiService
    {
        Task<UsuarioVM> CrearUsuario(UsuarioVM x);
        Task<UsuarioVM> IniciarSesion(UsuarioVM a);
    }
}
