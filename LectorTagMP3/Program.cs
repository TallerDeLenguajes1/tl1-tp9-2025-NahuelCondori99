using System.Runtime.CompilerServices;
using Elpiu;

class Program
{
    static void Main(string[] args)
    {
        string rutaMP3 = "D:/Facultad/Taller de lenguaje 1/TP9_NoSubir/LectorTagMp3/12 Al vacío.mp3";
        //Copio la ruta donde se encuentra mi archivo mp3

        if (File.Exists(rutaMP3))
        {
            Console.WriteLine("Todo joya pa ;)");
        }
        else
        {
            Console.WriteLine("Todo mal pa :(");
        }

        byte[] buffer = new byte[128];
        Id3v1Tag miObjetoPu;

        using (FileStream infoArchivo = new FileStream(rutaMP3, FileMode.Open))
        {
            infoArchivo.Seek(-128, SeekOrigin.End);
            infoArchivo.Read(buffer, 0, 128);
            string header = leer(buffer, 0, 3);
            string titulo = leer(buffer, 3, 30);
            string artista = leer(buffer, 33, 30);
            string album = leer(buffer, 63, 30);
            string anio = leer(buffer, 93, 4);
            string comentario = leer(buffer, 97, 30);
            string genero = leer(buffer, 127, 1);
            miObjetoPu = new Id3v1Tag(header, titulo, artista, album, anio, comentario, genero);
        }

        Console.WriteLine("-----DATOS-----");

        if (miObjetoPu.Header == "TAG")
        {
            Console.WriteLine($"Titulo: {miObjetoPu.Titulo}\nArtista: {miObjetoPu.Artista}\nAlbum: {miObjetoPu.Album}\nAnio: {miObjetoPu.Anio}\nComentario: {miObjetoPu.Comentario}\nGenero: {miObjetoPu.Genero}");
        }else
        {
            Console.WriteLine("Pan con queso");
        }
    }
    static string leer(byte[] buffer, int inicio, int longitud)
    {
        return System.Text.Encoding.GetEncoding("latin1").GetString(buffer, inicio, longitud).TrimEnd('\0');
    }
}