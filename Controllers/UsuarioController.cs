using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WhosAppMVCfront.Models;
using WhosAppMVCfront.Servicios;

namespace WhosAppMVCfront.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger logger;
        private readonly IConsumirApiService _consumirApiService;

        public UsuarioController(IConsumirApiService apiservice, ILogger<UsuarioController> loger)
        {
            _consumirApiService = apiservice;
            logger = loger;
        }

        public IActionResult CrearUsuario()
        {
            return View();
        }

        public async Task<IActionResult> Create(UsuarioVM usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _consumirApiService.CrearUsuario(usuario);

                    return RedirectToAction("Chat", "Usuario");
                }
                else
                {
                    return RedirectToAction("Error","Home");
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation("Ocurrio un error" + ex.Message);
                throw;
            }


        }

        public async Task<IActionResult> LoginPost(UsuarioVM usuario)
        {


            var result = await _consumirApiService.IniciarSesion(usuario);
            if (result == null)
            {
                


                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                

                return RedirectToAction("ChatGrupal", "Chat");
            }


        }

        public IActionResult Login()
        {
            return View();
        }


    }
}
