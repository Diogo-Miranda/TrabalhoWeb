using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabalhoWebV1.Models;

namespace TrabalhoWebV1.Controllers
{
    public class HomeController : Controller
    {
        private AppContext ctx;
        public IActionResult Index()
        {
            return View();
        }

        public HomeController(AppContext ctx)
        {
            this.ctx = ctx;
        }
        
        [HttpPost]
        public IActionResult Index(Desenvolvedor d)
        {
            Desenvolvedor desenvolvedor = ctx.Desenvolvedors.Where(a => a.email == d.email && a.senha == d.senha).FirstOrDefault();
            if (desenvolvedor != null)
            {
                HttpContext.Session.SetInt32("Id", desenvolvedor.Id);
                HttpContext.Session.SetString("email", desenvolvedor.email);
                HttpContext.Session.SetInt32("adm", desenvolvedor.adm ? 1 : 0);

                ViewBag.Projeto = ctx.Projetos;

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.Mensagem = "Usuario não encontrado!";

                return View();
            }
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Desenvolvedor d)
        {
            if (ModelState.IsValid)
            {
                ctx.Desenvolvedors.Add(d);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Cadastro", d);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
