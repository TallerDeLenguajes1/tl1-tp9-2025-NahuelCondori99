using System.IO;


string pathB;

do
{
    Console.WriteLine("Ingresar el PATH del directorio que desea analizar:");
    pathB = Console.ReadLine();

    if (Directory.Exists(pathB))
    {
        Console.WriteLine("El directorio " + pathB + " existe");
    }
    else
    {
        Console.WriteLine("El directorio " + pathB + " no existe");
    }

    Console.WriteLine("Ingresar un PATH valido: ");
    pathB = Console.ReadLine();

} while (!Directory.Exists(pathB));

Console.WriteLine("-----CARPETAS-----");

String[] carpetas = Directory.GetDirectories(pathB);

foreach (var carpeta in carpetas)
{
    Console.WriteLine(Path.GetFileName(carpeta));
}