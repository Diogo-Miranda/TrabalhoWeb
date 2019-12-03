using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoWebV1.Models;

namespace TrabalhoWebV1.Controllers
{
    public class ProjetoController : Controller
    {
        private AppContext ctx;

        public ProjetoController(AppContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Projetos = ctx.Projetos;

            return View();
        }

        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo";

            return View("Form");
        }

        [HttpPost]
        public IActionResult Novo(Projeto p)
        {
            if (ModelState.IsValid)
            {
                ctx.Projetos.Add(p);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", p);
            }
        }

        public IActionResult Editar(int id)
        {
            ViewData["Title"] = "Editar";

            Projeto p = ctx.Projetos.Find(id);

            if (p != null)
            {
                return View("Form", p);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Projeto p)
        {
            if (ModelState.IsValid)
            {
                ctx.Projetos.Update(p);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", p);
            }
        }

        public IActionResult Del(int id)
        {
            Projeto p = ctx.Projetos.Find(id);

            if (p != null)
            {
                ctx.Projetos.Remove(p);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
