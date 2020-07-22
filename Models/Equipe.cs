using System;
using System.Collections.Generic;
using System.IO;
using E_Players_ASPNETCORE.Interfaces;

namespace E_Players_ASPNETCORE.Models
{
    public class Equipe : EPlayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }

        //o csv nao consegue guardar imagem, então será sempre salvo o caminho dela (link)
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        //Metodo construtor
        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        public void Crate(Equipe e)
        {
            string[] linha = {PrepararLinha(e)};
            File.AppendAllLines(PATH, linha);

            //PATH será sempre a constante e o caminho
        }

        private string PrepararLinha(Equipe e )
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

         /// <summary>
         /// Metodo que deletar alguma informação desejada
         /// </summary>
         /// <param name="idEquipe">Vai retornar as linhas que nao foram excluidas a partir do Do Reescrever CSV</param>
        public void Delete(int idEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll( x => x.Split(";")[0] == IdEquipe.ToString());

            ReescreverCSV(PATH,linhas);

        }
        /// <summary>
        /// Metodo para armazenar os dados csv
        /// </summary>
        /// <returns>Uma lista das equipes</returns>
        public List<Equipe> ReadAll()
        {
             List<Equipe> equipes = new List<Equipe>();
             /// <summary>
             /// Metodo de le as linhas
             /// </summary>
             /// <returns>E retorna no csv</returns>
            string[] linhas = File.ReadAllLines(PATH);

            ///Depois varremos essa informações, separando com split e cria o novo objeto equipe
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll( x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(PrepararLinha (e));
            ReescreverCSV(PATH,linhas);
        }
    }
}