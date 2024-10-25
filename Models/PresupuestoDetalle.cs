public class PresupuesoDetalle
{
    private Producto producto;
    private int cantidad;

    public PresupuesoDetalle()
    {
    }

    public Producto Producto { get => producto; set => producto = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
}