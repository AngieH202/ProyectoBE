using BackEndAngie.Data;
using BackEndAngie.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAngie.Services;

public class ProductoService
{
    private readonly DataContext _context;

    public ProductoService(DataContext context)
    {
        _context = context;
    }

    // Obtener todos los productos
    public async Task<List<Productos>> ObtenerProductos()
    {
        return await _context.Productos.ToListAsync();
    }

    // Obtener un producto por ID
    public async Task<Productos?> ObtenerProductoPorId(Guid id)
    {
        return await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
    }

    // Crear un producto
    public async Task<Productos> CrearProducto(Productos producto)
    {
        producto.Id = Guid.NewGuid();
        producto.CreatedAt = DateTime.UtcNow;

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return producto;
    }

    // Actualizar un producto
    public async Task<bool> ActualizarProducto(Guid id, Productos productoActualizado)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        producto.Nombre = productoActualizado.Nombre;
        producto.Categoria = productoActualizado.Categoria;
        producto.Precio = productoActualizado.Precio;
        producto.Cantidad = productoActualizado.Cantidad;

        await _context.SaveChangesAsync();
        return true;
    }

    // Eliminar un producto
    public async Task<bool> EliminarProducto(Guid id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return true;
    }
}