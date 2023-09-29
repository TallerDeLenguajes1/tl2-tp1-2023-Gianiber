using Cadeteria;
using System.Collections.Generic;
using System.IO;

Cliente Jorge = new Cliente();
Cadete Marcos = new Cadete(0, "Marcos", "Junin 347", 3815999888);
Cadete Luis = new Cadete(1, "Luis", "Salta 987", 3815111222);
NuevaCadeteria ProntoVoy = new NuevaCadeteria();
Pedidos Pollo = new Pedidos(0, "Pollo picante", Jorge);
Pedidos Sanguche = new Pedidos(1, "Completo sin aji", Jorge);
List<Cadete> ListaC = new List<Cadete>();
List<Pedidos> ListaP = new List<Pedidos>();

Jorge.Nombre = "Jorge";
Jorge.Telefono = 3815975734;
Jorge.Direccion = "Santo Domingo 2070";
Jorge.DatosReferenciaDireccion = "Porton negro";

Console.WriteLine("La direccion es: " + Jorge.DireccionCliente());

ListaC.Add(Marcos);
ListaC.Add(Luis);
ListaP.Add(Pollo);
ListaP.Add(Sanguche);


ProntoVoy.ListadoCadetes = ListaC;
ProntoVoy.ListadoPedidos = ListaP;

ProntoVoy.asignarCadeteAPedido(0, 1);

foreach (Pedidos item in ProntoVoy.ListadoPedidos)
{
    if (item.Encargado >= 0)
    {
        foreach (Cadete cadeteX in ProntoVoy.ListadoCadetes)
        {
            if (cadeteX.Id == item.Encargado)
            {
                Console.WriteLine("\nEl pedido " + item.Nro + " esta a cargo de " + cadeteX.Nombre);
            }
        }
    }
    else
    {
        Console.WriteLine("\nEl pedido " + item.Nro + " no tiene cadete a cargo");
    }
}