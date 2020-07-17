using System.Collections.Generic;
using E_Players_ASPNETCORE.Models;

namespace E_Players_ASPNETCORE.Interfaces
{
    public interface INoticia
    {
          //criar
        void Crate(Noticia n);

         //Ler
        List<Noticia> ReadAll();

         //Alterar
         void Update(Noticia n);

         //Excluir
         void Delete(int idnoticia);

    }
}