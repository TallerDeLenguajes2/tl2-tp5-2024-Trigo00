using Microsoft.Data.Sqlite;

public class ProductoRepository
{

    private string cadenaConnection = "Data Source=db/Tienda.db;Cache=Shared";

    public void CrearProducto(Producto producto)
    {
        var query = $"INSERT INTO Producto (idProducto, Descripcion, Precio) VALUES (@idProducto, @descripcion, @precio)";
        using (SqliteConnection connection = new SqliteConnection(cadenaConnection))
        {
            connection.Open();

            var command = new SqliteCommand(query, connection);

            command.Parameters.Add(new SqliteParameter(@"idProducto", producto.IdProducto));
            command.Parameters.Add(new SqliteParameter(@"descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter(@"precio", producto.Precio));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    public void ModificarProducto(int id, Producto producto)
    {
        var query = $"UPDATE Producto SET Descripcion = @descripcion, Precio = @precio WHERE idProducto = @idProducto";
        using (SqliteConnection connection = new SqliteConnection(cadenaConnection))
        {
            connection.Open();

            var command = new SqliteCommand(query, connection);

            // Agrega los parámetros
            command.Parameters.Add(new SqliteParameter(@"descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter(@"precio", producto.Precio));
            command.Parameters.Add(new SqliteParameter(@"idProducto", id));

            // Ejecuta el comando
            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    public List<Producto> ListarProductos()
    {
        var query = "SELECT * FROM Productos";
        List<Producto> productos = new List<Producto>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConnection))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();

            using(SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToInt32(reader["Precio"]);
                    productos.Add(producto);
                }
            }
            connection.Close();
        }
        return productos;
    }

}