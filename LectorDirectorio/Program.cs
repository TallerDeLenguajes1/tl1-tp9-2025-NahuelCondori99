using System.IO;


string pathB;

do
{
    Console.WriteLine("Ingresar el PATH del directorio que desea analizar:");
    pathB = Console.ReadLine();

    if (Directory.Exists(pathB))
    {
        Console.WriteLine("El directorio " + pathB + " existe");
        break;
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

Console.WriteLine("-----ARCHIVOS-----");

string[] archivos = Directory.GetFiles(pathB);

List<string> lineasCSV = new List<string>
{
    "Nombre del archivo;Tamanio en Kb;Fecha ultima modificacion"
};

foreach (var archivo in archivos)
{
    FileInfo dato = new FileInfo(archivo);
    double tamanioDato = (dato.Length) / 1024;
    string nombreArchivo = dato.Name;
    DateTime fechaUltimaModificacion = dato.LastWriteTime;
    Console.WriteLine("Nombre del archivo: " + nombreArchivo + "---" + " Tamanio: " + tamanioDato + " Kb" + "---" + " Ultima fecha de modificacion: " + fechaUltimaModificacion);
    string agregarLista = $"{nombreArchivo}; {tamanioDato}; {fechaUltimaModificacion}";

    lineasCSV.Add(agregarLista);

}

string ArchivoCSV = Path.Combine(pathB, "Archivo_CSV.csv");
File.WriteAllLines(ArchivoCSV, lineasCSV);
Console.WriteLine("Se cargaron los datos.");