using System.Collections.Generic;
using E_Players_ASPNETCORE.Models;

namespace E_Players_ASPNETCORE.Interfaces
{
    public interface IEquipe
    {
         //criar
        void Crate(Equipe e);

         //Ler
        List<Equipe> ReadAll();

         //Alterar
         void Update(Equipe e);

         //Excluir
         void Delete(int idEquipe);

    }
}