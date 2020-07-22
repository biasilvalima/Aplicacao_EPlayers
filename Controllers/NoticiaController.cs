using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_ASPNETCORE.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_Players_ASPNETCORE.Controllers
{
    public class NoticiaController : Controller
    {
            Noticia noticiaModel = new Noticia();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticia novaNoticia = new Noticia();
            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo = form["Titulo"];

           /// <summary>
            /// gora a imagem não é mais um arquivo de texto, agora ela passa a ser file e coseguimos trazer ela pelo nome atraves das pastas.Então cria o diretorio se ainda nao existir, depois passa pras estrurturas das pastas e atribui a imagem ao objeto"
            /// </summary>
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload Final


            noticiaModel.Crate(novaNoticia);

            ViewBag.Noticias = noticiaModel.ReadAll();
            return LocalRedirect("~/Noticia");
        }

         [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticia");
        }

    }
}
