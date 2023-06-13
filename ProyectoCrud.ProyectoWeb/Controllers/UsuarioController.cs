using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.Models;
using ProyectoCrud.ProyectoWeb.Models.ViewModels;
using ProyectoCrud.ServicioWCF.Servicio;
using System.Globalization;

namespace ProyectoCrud.ProyectoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController
        public ActionResult UsuarioConsulta()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Usuario> queryUsuariosSQL = await _usuarioService.ObtenerTodos();

            List<VMUsuario> lista = queryUsuariosSQL
                                     .Select(C => new VMUsuario()
                                     {
                                         Id = C.Id,
                                         Nombre = C.Nombre,
                                         FechaNacimiento = C.FechaNacimiento.Value.ToString("dd/MM/yyyy"),
                                         Sexo = C.Sexo

                                     }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }


        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMUsuario modelo)
        {
            Usuario NuevoModelo = new Usuario()
            {
                Nombre = modelo.Nombre,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento,"dd/MM/yyyy",CultureInfo.CreateSpecificCulture("es-CO")),
                Sexo = modelo.Sexo
            };

            bool respuesta = await _usuarioService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMUsuario modelo)
        {
            Usuario NuevoModelo = new Usuario()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                Sexo = modelo.Sexo
            };

            bool respuesta = await _usuarioService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            
            bool respuesta = await _usuarioService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }



        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
