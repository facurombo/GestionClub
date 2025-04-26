public class Socio
{
    public string Nombre { get; set; }
    public ulong Legajo { get; set; }
    public int Edad { get; set; }

    public Socio(string nombre, ulong legajo, int edad)
    {
        Nombre = nombre;
        Legajo = legajo;
        Edad = edad;
    }

    public string MostrarDatos()
    {
        return $"Nombre: {Nombre}\nLegajo: {Legajo}\nEdad: {Edad}";
    }
}