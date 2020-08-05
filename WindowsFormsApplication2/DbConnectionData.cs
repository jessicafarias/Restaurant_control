using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using Devart.Data.PostgreSql;

namespace MyConnection
{
    public class Socios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Administrador { get; set; }

        public Socios(bool administrador, string nombre, string contraseña, int id)
        {
            Administrador = administrador;
            Nombre = nombre;
            Contraseña = contraseña;
            Id = id;

        }
        public override string ToString()
        {
            return string.Format("{0}", Nombre);
        }


    }

    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Producto() { }

        public Producto(int id, string codigo, string descripcion, decimal precio)
        {
            Id = id;
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
        }
        public override string ToString()
        {
            return string.Format("{0}", Descripcion);
        }
     
    }

    public class Inventario: Producto
    {
        public int Cantidad { get; set; }
        public Inventario() { }
        public Inventario(string codigo, string descripcion, int cantidad)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Cantidad = cantidad;
        }
    }

    public class Estatus
    {
        public decimal Monto { get; set; }
        public string Modificaciones { get; set; }
        public DateTime fechaModificacion { get; set; }
        public decimal Total { get; set; }

        public Estatus() { }
        public Estatus(decimal montomodificacion, string modificaciontipo, DateTime fecha)
        {
            Monto = montomodificacion;
            Modificaciones = modificaciontipo;
            fechaModificacion = fecha;
        }
        
    }

    public sealed class Ventas
    {
        public int Id_producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_de_venta { get; set; }
        public DateTime Fecha_venta { get; set; }

        public Ventas() { }

        public Ventas(int id_productos, int cantidad, decimal precio_de_venta, DateTime fecha_venta)
        {
            Id_producto = id_productos;
            Cantidad = cantidad;
            Precio_de_venta = precio_de_venta;
            Fecha_venta = fecha_venta;
        }

    }

    //public sealed class Inventario
    //{
    //    public int Cantidad { get; set; }
    //    public int id { get; set; }
    //    public Inventario() { }
    //    public Inventario(int cantidad, int )
    //}

    public partial class DbConnection
    {
        public void AgregarProducto2(int a, string Nombre_producto, string CodigoDeBarra, string precio)
        {

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "    INSERT INTO productos(id, codigo, descripcion, precio) " +
                                    "VALUES( " + a + ",'" + CodigoDeBarra + "' , '" + Nombre_producto + "', " + precio + ")";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO inventario (id, existencias) VALUES (" + a + ", 0);";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }       

        }
        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> pro = new List<Producto>();

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = " SELECT * FROM productos";
                //SELECT *FROM productos WHERE codigo = '123456'
                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        pro.Add(new Producto(dr.GetInt32("id"), dr.GetString("codigo"), dr.GetString("descripcion"), dr.GetDecimal("precio")));
                    }

                }
            }

            return pro;
        }
        public Producto ObtenerProductoPorCodigo_barras(string CodigoDeBarra)
        {
            Producto pro = new Producto();

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = " SELECT * FROM productos WHERE codigo = '" + CodigoDeBarra + "'";
                //SELECT *FROM productos WHERE codigo = '123456'


                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        pro = (new Producto(dr.GetInt32("id"), dr.GetString("codigo"), dr.GetString("descripcion"), dr.GetDecimal("precio")));
                    }

                }
            }
            return pro;
        }
        public List<Ventas> ObtenerListaVENTASIntervaloDeFecha(DateTime dia1, DateTime dia2)
        {
            List<Ventas> listpro = new List<Ventas>();


            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = " SELECT * FROM ventas ORDER BY id";
                ///select *FROM ventas WHERE fecha_venta= '2015/12/12'

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        DateTime fechaDeVenta = dr.GetDateTime("fecha_venta");
                        if (fechaDeVenta >= dia1)
                        {
                            if (fechaDeVenta <= dia2)
                            {
                                listpro.Add(new Ventas(dr.GetInt32("id_productos"), dr.GetInt32("cantidad"), dr.GetDecimal("precio_de_venta"), dr.GetDateTime("fecha_venta")));
                            }
                        }
                    }

                    dr.Close();
                }
            }
            return listpro;
        }
        public List<Ventas> ObtenerListaVENTASDelDía()
        {
            List<Ventas> listpro = new List<Ventas>();


            DateTime fechaActual = DateTime.Today;

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = " SELECT * FROM ventas ORDER BY id";
                ///select *FROM ventas WHERE fecha_venta= '2015/12/12'

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        DateTime fechaDeVenta = dr.GetDateTime("fecha_venta");
                        if (fechaDeVenta == fechaActual)
                            listpro.Add(new Ventas(dr.GetInt32("id_productos"), dr.GetInt32("cantidad"), dr.GetDecimal("precio_de_venta"), dr.GetDateTime("fecha_venta")));
                    }

                    dr.Close();
                }
            }
            return listpro;
        }
        public Producto ObtenerProductoNombre(string Nombre)
        {
            Producto pro = new Producto();

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = " select *FROM productos WHERE descripcion='" + Nombre + "'";
                ///select *FROM ventas WHERE fecha_venta= '2015/12/12'

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read() == true)
                    {
                        pro = new Producto(dr.GetInt32("id"), dr.GetString("codigo"), dr.GetString("descripcion"), dr.GetDecimal("precio"));
                    }

                    dr.Close();
                }
                return pro;
            }
        }
        public int NumeroMaximoDeProductos()
        {
            int numeromaximo = 0;

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT max(id)  from  productos; ";

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        numeromaximo = dr.GetInt32("max");
                    }

                    dr.Close();
                }
            }

            return numeromaximo + 1;
        }
        public List<Socios> ObtenerSocios()
        {
            List<Socios> list = new List<Socios>();
            using (PgSqlCommand comand = conn.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM socios";


                using (PgSqlDataReader dr = comand.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        list.Add(new Socios(dr.GetBoolean("administrador"), dr.GetString("nombre"), dr.GetString("contra"), dr.GetInt32("id")));
                    }
                    dr.Close();
                }
                return list;
            }
        }
        public List<Inventario> Inventariado()
        {
            List<Inventario> list = new List<Inventario>();
            using (PgSqlCommand comand = conn.CreateCommand())
            {
                comand.CommandText = "SELECT p.codigo, p.descripcion, i.existencias FROM productos p INNER JOIN inventario i ON p.id= i.id ORDER BY existencias";


                using (PgSqlDataReader dr = comand.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        list.Add(new Inventario(dr.GetString("codigo"), dr.GetString("descripcion"), dr.GetInt32("existencias")));
                    }
                    dr.Close();
                }
                return list;
            }
        }
        public void ModificarInventario(int id)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE inventario set existencias = existencias-1 WHERE id=" + id + "";

                    ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                    cmd.ExecuteNonQuery();
               }                
        }
        public void ModificarInventario(int id, int entradas)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE inventario set existencias = existencias+"+entradas+" WHERE id=" + id + "";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }
        }
        public void ModificarProducto3(int id, string precio)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "   UPDATE productos set precio =" + precio + " WHERE id=" + id + "";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }
        }
        public void ModificarProductoIdIdStringDes(int id, string descripcion)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "   UPDATE productos set descripcion ='" + descripcion + "' WHERE id=" + id + "";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }
        }
        public void ModificarProductoStringCodID(string codigoBarras, int id)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "   UPDATE productos set codigo =" + codigoBarras + " WHERE id=" + id + "";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }
        }
        public List<Estatus> Estatus(DateTime fecha1, DateTime fecha2)
        {
            fecha1= Convert.ToDateTime(fecha1.ToShortDateString());
            fecha2 = Convert.ToDateTime(fecha2.ToShortDateString());
            fecha1 = Convert.ToDateTime(fecha1);
            fecha2 = Convert.ToDateTime(fecha2);
            List<Estatus> lista = new List<Estatus>();
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = " select*from Modifica";

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        DateTime fechaRegistro = dr.GetDateTime("fecha");
                        if ((fechaRegistro>= fecha1)&&(fechaRegistro<=fecha2))
                        {
                            lista.Add(new Estatus(dr.GetDecimal("modificaciones"), dr.GetString("tipo"), dr.GetDateTime("fecha")));
                        }
                    }

                    dr.Close();
                }
            }
            return lista;
        }
        public List<Estatus> Estatus()
        {
            List<Estatus> lista = new List<Estatus>();
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = " select*from Modifica";

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                            lista.Add(new Estatus(dr.GetDecimal("modificaciones"), dr.GetString("tipo"), dr.GetDateTime("fecha")));
                        
                    }

                    dr.Close();
                }
            }
            return lista;
        }
        public void MovimientosCaja(string cantidadDiner, string retirooingreso, DateTime fecha)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "   INSERT INTO Modifica(modificaciones,tipo,fecha) VALUES ("+cantidadDiner+",'"+retirooingreso+"','"+fecha.ToShortDateString()+"');";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }
            if (retirooingreso == "RETIRO")
            {
                using (PgSqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Caja SET total = total-" + cantidadDiner + "";

                    ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                    cmd.ExecuteNonQuery();
                }
            }
            else if (retirooingreso == "INGRESO")
            {
                using (PgSqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Caja SET total = total+" + cantidadDiner + "";

                    ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                    cmd.ExecuteNonQuery();
                }
            }
            else if (retirooingreso == "RETIRO PROVEDOR")
            {
                using (PgSqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Caja SET total = total-" + cantidadDiner + "";

                    ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public decimal VerTotal()
        {
            decimal total = 0;

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select *from Caja WHERE id=1;";
                //SELECT *FROM productos WHERE codigo = '123456'
                
                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                       total= (dr.GetDecimal("total"));
                    }

                }
            }
            return total;
        }
        public void Venta(string cantidad)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Caja SET total = total+" + cantidad + "";

                ///// INSERT INTO productos(id, codigo, descripcion,precio) VALUES (1,123456, 'chococrispis 750g', 58.5);
                cmd.ExecuteNonQuery();
            }
        }
        public bool Existencia(int id)
        {
            bool ex = false;
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select *from inventario WHERE id="+id+"";
                //SELECT *FROM productos WHERE codigo = '123456'

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        if((dr.GetDecimal("existencias")>=1))
                        {
                            ex = true;
                        }
                    }

                }
            }
            return ex;
        }
        public bool NuevoIngreso()
        {
            bool ex = false;
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select nombre from socios";

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                            if (Convert.ToString(dr.GetString("nombre")) != "")
                            {
                                ex = true;
                            }
                    }

                }
            }
            return ex;
        }
        public void AgregarSocioUnico(int a, string usuarionomb, string contraseña)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "    INSERT INTO socios(administrador,nombre, contra, id) " +
                                    "VALUES( 'true','" + usuarionomb + "' , '" + contraseña + "', 1)";
                cmd.ExecuteNonQuery();
            }
        }

        public void Numero(string numero)
        {
            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "  UPDATE Numero set numero = "+numero+"";
                cmd.ExecuteNonQuery();
            }
        }
        public decimal getNumero()
        {
            decimal total = 0;

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select *from Numero";

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() == true)
                    {
                        total = (dr.GetDecimal("numero"));
                    }
                }
            }
            return total;
        }
               
    }
}
