using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Modelos;

namespace  Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// Interfaz (Api Contract)
    /// Permite definir los métodos que permitiran acceder la lógica de negocio
    /// Aislando la capa de acceso a datos de los demás módulos que consumen los
    /// datos
    /// </summary>
    public interface ICategoriaRepo
    {
        // /// <summary>
        // /// Método sincrono
        // /// Permite obtener la lista de categorías desde la base
        // /// </summary>
        // /// <returns></returns>
        // IEnumerable<Categoria> GetCategorias();

        /// <summary>
        /// Método Asíncrono
        /// Permite obtener la lista de categorías desde la base 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        /// <summary>
        /// Permite obtener la información de la categoría asociada al 
        /// identificador pasado por parametro
        /// </summary>
        /// <param name="id">Identificador de la categoría</param>
        /// <returns></returns>
        Task<Categoria> GetCategoriasAsyncById(int id);

        void crearCategoria(Categoria categoria);
        void editarCategoria(int id, Categoria categoria);
        void eliminarCategoria(Categoria categoria);
        Task<Categoria> guardarCategoria(Categoria categoria);
    }
}
