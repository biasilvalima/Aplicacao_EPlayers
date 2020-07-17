using System;
using System.Collections.Generic;
using System.IO;
using E_Players_ASPNETCORE.Interfaces;

namespace E_Players_ASPNETCORE.Models
{
    public class Noticia : EPlayersBase , INoticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/Noticia.csv";

        public Noticia()
        {
            CreateFolderAndFile(PATH);
        }
        public void Crate(Noticia n)
        {
            string[] linha = {PrepararLinha (n)};
            File.AppendAllLines(PATH, linha);

        }

        private string PrepararLinha(Noticia n)
        {
            return$"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }


        public void Delete(int idnoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll( z => z.Split(";")[0] == IdNoticia.ToString());

            ReescreverCSV(PATH, linhas);
        }

        public List<Noticia> ReadAll()
        {
             List<Noticia> noticias = new List<Noticia>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticia noticia = new Noticia();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }

        public void Update(Noticia n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll( z => z.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(PrepararLinha (n));
            ReescreverCSV(PATH, linhas);
        }
    }
}