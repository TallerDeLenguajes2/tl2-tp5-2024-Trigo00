public class PresupuestoRepository
{
    private string cadenaConnection = "Data Source=db/Tienda.db;Cache=Shared";

    public void CrearPresupuesto(Presupuesto presupuesto)
    {
        var query = "INSERT INTO Presupuesto(idPresupuesto, NombreDestinatario)";
    }
}