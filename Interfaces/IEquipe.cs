using System.Collections.Generic;
using E_Players_ASPNETCORE.Models;

namespace E_Players_ASPNETCORE.Interfaces
{
    public interface IEquipe
    {
         //criar
        void Crate(Equipe e);

         /// <summary>
         /// Le todos os arquivos do csv
         /// </summary>
         /// <returns>Retorna uma lista</returns>
        List<Equipe> ReadAll();

         /// <summary>
         /// Altera um metodo
         /// </summary>
         /// <param name="e"></param>
         void Update(Equipe e);

         //Excluir
         void Delete(int idEquipe);

    }
}