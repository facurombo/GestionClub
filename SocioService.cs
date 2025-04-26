using System;
using System.Collections.Generic;
using System.IO;

public static class SocioService
{
    private const string archivoSocios = "socios.txt";

    // Método para leer los socios desde el archivo
    public static List<Socio> LeerSocios()
    {
        List<Socio> listaSocios = new List<Socio>();

        try
        {
            using (StreamReader sr = new StreamReader(archivoSocios))
            {
                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    var datos = linea.Split(';');
                    if (datos.Length == 3)
                    {
                        string nombre = datos[0].Trim();
                        ulong legajo = ulong.Parse(datos[1].Trim());
                        int edad = int.Parse(datos[2].Trim());
                        listaSocios.Add(new Socio(nombre, legajo, edad));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al leer el archivo: {e.Message}");
        }

        return listaSocios;
    }

    // Método para agregar un socio al archivo
    public static void AgregarSocio(Socio nuevo)
    {
        try
        {
            File.AppendAllText(archivoSocios, $"{nuevo.Nombre};{nuevo.Legajo};{nuevo.Edad}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al agregar el socio: {e.Message}");
        }
 
    
    }

    // Método para borrar un socio del archivo
    public static void BorrarSocio(ulong legajo)
    {
        List<Socio> listaSocios = LeerSocios();
        List<Socio> listaFiltrada = listaSocios.FindAll(s => s.Legajo != legajo);

        try
        {
            using (StreamWriter sw = new StreamWriter(archivoSocios))
            {
                foreach (var socio in listaFiltrada)
                {
                    sw.WriteLine($"{socio.Nombre};{socio.Legajo};{socio.Edad}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al borrar el socio: {e.Message}");
        }
    }
}