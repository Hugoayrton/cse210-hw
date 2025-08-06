using System;
using System.Collections.Generic;


public class Comment
{
    public string Nombre { get; }
    public string Texto { get; }

    public Comment(string nombre, string texto)
    {
        Nombre = nombre;
        Texto = texto;
    }
}


public class Video
{
    private string _titulo;
    private string _autor;
    private int _duracionSegundos;
    private List<Comment> _comentarios;

    public Video(string titulo, string autor, int duracionSegundos)
    {
        _titulo = titulo;
        _autor = autor;
        _duracionSegundos = duracionSegundos;
        _comentarios = new List<Comment>();
    }

    public void AgregarComentario(Comment comentario)
    {
        _comentarios.Add(comentario);
    }

    public int ObtenerNumeroComentarios()
    {
        return _comentarios.Count;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Título: {_titulo}");
        Console.WriteLine($"Autor: {_autor}");
        Console.WriteLine($"Duración: {_duracionSegundos} segundos");
        Console.WriteLine($"Número de comentarios: {ObtenerNumeroComentarios()}");

        foreach (var comentario in _comentarios)
        {
            Console.WriteLine($" - {comentario.Nombre}: {comentario.Texto}");
        }

        Console.WriteLine(); // Espacio entre videos
    }
}
class Program
{
    static void Main(string[] args)
    {
        
        List<Video> videos = new List<Video>();

      
        Video video1 = new Video("Introducción a C#", "Juan Pérez", 300);
        video1.AgregarComentario(new Comment("Ana", "Muy buen video, gracias!"));
        video1.AgregarComentario(new Comment("Luis", "¿Habrá una segunda parte?"));
        video1.AgregarComentario(new Comment("Carla", "Me ayudó mucho, excelente explicación."));
        videos.Add(video1);

       
        Video video2 = new Video("Tutorial de Unity", "Sofía Gómez", 600);
        video2.AgregarComentario(new Comment("Mario", "¡Justo lo que necesitaba!"));
        video2.AgregarComentario(new Comment("Lucía", "Muy claro todo."));
        video2.AgregarComentario(new Comment("Pedro", "Gran trabajo."));
        videos.Add(video2);

      
        Video video3 = new Video("Aprende SQL desde cero", "Carlos Ramírez", 450);
        video3.AgregarComentario(new Comment("Elena", "Buen contenido, gracias."));
        video3.AgregarComentario(new Comment("Roberto", "Muy útil para principiantes."));
        video3.AgregarComentario(new Comment("María", "Excelente como siempre."));
        videos.Add(video3);

      
        foreach (Video video in videos)
        {
            video.MostrarInformacion();
        }
    }
}