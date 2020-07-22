using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_ASPNETCORE.Models;
using Microsoft.AspNetCore.Http;

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
            novaNoticia.Imagem = form["Imagem"];

            noticiaModel.Crate(novaNoticia);

            ViewBag.Noticias = noticiaModel.ReadAll();
            return LocalRedirect("~/Noticia");
        }

    }
}
