using ProyectoCrud.DAL.Repositorio;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.ServicioWCF.Servicio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepo;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<bool> Actualizar(Usuario modelo)
        {
            return await _usuarioRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _usuarioRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            return await _usuarioRepo.Insertar(modelo);
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _usuarioRepo.Obtener(id);
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _usuarioRepo.ObtenerTodos();
        }
    }
}
