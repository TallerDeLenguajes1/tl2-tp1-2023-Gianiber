using System.Text.Json;
using System.Collections.Generic;

namespace Cadeteria
{
    enum EstadoPedido
    {
        Pendiente,
        Realizada
    }
    public class Cliente
    {
        string nombre;
        string direccion;
        uint telefono;
        string datosReferenciaDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
        public string DireccionCliente()
        {
            return this.Direccion;
        }
        public void DatosCliente()
        {
            Console.WriteLine("Datos del cliente:\n");
            Console.WriteLine("Nombre: " + this.Nombre + "\n");
            Console.WriteLine("Telefono: " + this.Telefono + "\n");
            Console.WriteLine("Direccion (datos de referencia): " + this.Direccion + " (" + this.DatosReferenciaDireccion + ")\n");
        }
    }
    public class Pedidos
    {
        int nro;
        string obs;
        Cliente cliente;
        EstadoPedido estado;
        int encargado;
        public Pedidos(int numero, string observacion, Cliente cl)
        {
            this.nro = numero;
            this.obs = observacion;
            this.cliente = cl;
            this.estado = EstadoPedido.Pendiente;
            this.encargado = -1;
        }
        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public int Encargado { get => encargado; set => encargado = value; }
        internal EstadoPedido Estado { get => estado; set => estado = value; }
    }
    public class Cadete
    {
        int id;
        string nombre;
        string direccion;
        uint telefono;

        public Cadete(int ide, string name, string dire, uint tel)
        {
            this.Id = ide;
            this.Nombre = name;
            this.Direccion = dire;
            this.Telefono = tel;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
    }

    public class NuevaCadeteria
    {
        string nombre;
        int telefono;
        List<Cadete> listadoCadetes;
        List<Pedidos> listadoPedidos;
        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public int jornalACobrar(int id)
        {
            int monto = 0, paga = 500;
            foreach (Pedidos pedidoX in listadoPedidos)
            {
                if (pedidoX.Encargado == id)
                {
                    if (pedidoX.Estado == EstadoPedido.Realizada)
                    {
                        monto = monto + paga;
                    }
                }
            }
            return monto;
        }
        public void asignarCadeteAPedido(int nro, int id)
        {
            foreach (Pedidos pedidoX in listadoPedidos)
            {
                if (pedidoX.Nro == nro)
                {
                    foreach (Cadete cadeteX in listadoCadetes)
                    {
                        if (cadeteX.Id == id)
                        {
                            pedidoX.Encargado = cadeteX.Id;
                        }
                    }
                }
            }
        }
        public void cambiarEstado(int nro)
        {
            foreach (Pedidos pedidoX in listadoPedidos)
            {
                if (pedidoX.Nro == nro)
                {
                    if (pedidoX.Estado == EstadoPedido.Pendiente)
                    {
                        pedidoX.Estado = EstadoPedido.Realizada;
                    }
                    else
                    {
                        pedidoX.Estado = EstadoPedido.Pendiente;
                    }
                }
            }
        }
        public void cambiarCadete(int nro, int id)
        {
            foreach (Cadete cadeteX in listadoCadetes)
            {
                if (cadeteX.Id == id)
                {
                    foreach (Pedidos pedidoX in listadoPedidos)
                    {
                        if (pedidoX.Nro == nro)
                        {
                            pedidoX.Encargado = id;
                        }
                    }
                }
            }
        }
    }
    public class AccesoADatos
    {
        //public void cargaCadete();
    }
    public class AccesoJSON
    {
        public List<Cadete> LeerCadetes(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                string cadetes = File.ReadAllText(nombreArchivo);
                List<Cadete> CadetesTexto = JsonSerializer.Deserialize<List<Cadete>>(cadetes);
                return CadetesTexto;
            }
            else
            {
                return null;
            }
        }
    }
    public class AccesoCSV
    {

    }
}