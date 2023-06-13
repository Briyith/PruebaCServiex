using Microsoft.EntityFrameworkCore;
using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositorio
{
    public class UsuarioRepository : IGenericRepository<Usuario>
    {
        private readonly DB_USUARIOContext _dbcontext;

        public UsuarioRepository(DB_USUARIOContext context)
        {
            _dbcontext = context;
        }


        public async Task<bool> Actualizar(Usuario modelo)
        {
            _dbcontext.Database.ExecuteSqlRaw("sp_actualizar_usuario {0}, {1}, {2}, {3}", modelo.Id, modelo.Nombre, modelo.FechaNacimiento, modelo.Sexo);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            _dbcontext.Database.ExecuteSqlRaw("sp_eliminar_usuario {0}", id);
            return true;


        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            _dbcontext.Database.ExecuteSqlRaw("sp_insertar_usuario {0}, {1}, {2}", modelo.Nombre, modelo.FechaNacimiento, modelo.Sexo);
            return true;
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _dbcontext.Usuarios.FindAsync(id);
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            IQueryable<Usuario> queryUsuarioSQL = _dbcontext.Usuarios;
            return queryUsuarioSQL;
        }
    }
}
