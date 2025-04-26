using System;
using System.Collections.Generic;

public class Programa
{
    static void Main()
    {
        string opcion;
        List<Socio> listaSocios = SocioService.LeerSocios();

        do
        {
            Console.Clear();
            listaSocios = SocioService.LeerSocios();
            Console.WriteLine("=== Menú de Gestión del Club ===");
            Console.WriteLine("1) Agregar socio");
            Console.WriteLine("2) Mostrar todos los socios");
            Console.WriteLine("3) Mostrar cantidad total de socios");
            Console.WriteLine("4) Mostrar edad promedio");
            Console.WriteLine("5) Mostrar cantidad por categoría");
            Console.WriteLine("6) Mostrar socio de mayor edad");
            Console.WriteLine("7) Borrar socio");
            Console.WriteLine("0) Salir");
            Console.Write("Elegí una opción: ");
            opcion = Console.ReadLine();
            Console.Clear();

            switch (opcion)
            {
                case "1":
                    AgregarSocio();
                    break;

                case "2":
                    MostrarSocios(listaSocios);
                    break;

                case "3":
                    MostrarCantidadSocios(listaSocios);
                    break;

                case "4":
                    MostrarEdadPromedio(listaSocios);
                    break;

                case "5":
                    MostrarPorCategoria(listaSocios);
                    break;

                case "6":
                    MostrarSocioMayorEdad(listaSocios);
                    break;

                case "7":
                    Console.Write("Ingrese el legajo del socio a eliminar: ");
                    ulong legajoBorrar = LeerULong("");
                    SocioService.BorrarSocio(legajoBorrar);
                    listaSocios = SocioService.LeerSocios(); // Actualizar la lista de socios
                    Console.WriteLine("Socio eliminado exitosamente.");
                    break;

                case "0":
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (opcion != "0")
            {
                Console.WriteLine("\nPresioná ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcion != "0");
    }

    private static void AgregarSocio()
    {
        Console.WriteLine("Agregar nuevo socio:");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Legajo: ");
        ulong legajo = LeerULong("Ingrese un número de legajo válido: ");

        Console.Write("Edad: ");
        int edad = LeerInt("Ingrese una edad válida: ");

        Socio nuevoSocio = new Socio(nombre, legajo, edad);
        SocioService.AgregarSocio(nuevoSocio);
        Console.WriteLine("Socio agregado exitosamente.");
    }

    private static void MostrarSocios(List<Socio> listaSocios)
    {
        if (listaSocios.Count > 0)
        {
            foreach (var s in listaSocios)
            {
                Console.WriteLine(s.MostrarDatos());
                Console.WriteLine("--------------------");
            }
        }
        else
        {
            Console.WriteLine("No hay socios registrados.");
        }
    }

    private static void MostrarCantidadSocios(List<Socio> listaSocios)
    {
        Console.WriteLine($"Total de socios: {listaSocios.Count}");
    }

    private static void MostrarEdadPromedio(List<Socio> listaSocios)
    {
        if (listaSocios.Count > 0)
        {
            double promedio = listaSocios.Average(s => s.Edad);
            Console.WriteLine($"Edad promedio de los socios: {promedio}");
        }
        else
        {
            Console.WriteLine("No hay socios registrados.");
        }
    }

    private static void MostrarPorCategoria(List<Socio> listaSocios)
    {
        // Implementar lógica para mostrar la cantidad por categoría.
    }

    private static void MostrarSocioMayorEdad(List<Socio> listaSocios)
    {
        var socioMayorEdad = listaSocios.OrderByDescending(s => s.Edad).FirstOrDefault();
        if (socioMayorEdad != null)
        {
            Console.WriteLine($"El socio de mayor edad es {socioMayorEdad.MostrarDatos()}");
        }
        else
        {
            Console.WriteLine("No hay socios registrados.");
        }
    }

    // Métodos auxiliares para leer datos del usuario
    private static ulong LeerULong(string mensaje)
    {
        ulong valor;
        while (!ulong.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine(mensaje);
        }
        return valor;
    }

    private static int LeerInt(string mensaje)
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine(mensaje);
        }
        return valor;
    }
}
