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
            _dbcontext.Usuarios.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Usuario modelo = _dbcontext.Usuarios.First(c => c.Id == id);
            _dbcontext.Usuarios.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;


        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            _dbcontext.Usuarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
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
