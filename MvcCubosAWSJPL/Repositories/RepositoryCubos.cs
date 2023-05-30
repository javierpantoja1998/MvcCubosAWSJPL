using Microsoft.EntityFrameworkCore;
using MvcCubosAWSJPL.Data;
using MvcCubosAWSJPL.Models;

namespace MvcCubosAWSJPL.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        private int GetMaxIdCubo()
        {
            if (this.context.Cubos.Count() != 0)
            {
                return this.context.Cubos.Max(x => x.IdCubo) + 1;
            }

            return 1;
        }
        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<Cubo> FindCuboAsync(int id)
        {
            return await this.context.Cubos.FirstOrDefaultAsync(x => x.IdCubo == id);
        }

        public async Task CreateCubo( string nombre,
            string marca, string imagen, int precio)
        {
            Cubo cubo = new Cubo();
            cubo.IdCubo = this.GetMaxIdCubo();
            cubo.Nombre = nombre;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            this.context.Cubos.Add(cubo);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCuboAsync
            (int id, string nombre,
            string marca, string imagen, int precio)
        {
            Cubo cubo = await this.FindCuboAsync(id);
            cubo.IdCubo = id;
            cubo.Nombre = nombre;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            await this.context.SaveChangesAsync();
        }


        public async Task DeleteCuboAsync(int id)
        {
            Cubo cubo = await this.FindCuboAsync(id);
            this.context.Cubos.Remove(cubo);
            await this.context.SaveChangesAsync();
        }
    }
}
