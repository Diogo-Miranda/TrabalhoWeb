using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoWebV1.Models;

namespace TrabalhoWebV1.Controllers
{
    public class RequisitoController : Controller
    {
        private AppContext ctx;

        public RequisitoController(AppContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Requisitos = ctx.Requisitos;

            return View();
        }

        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo";

            ViewBag.Projetos = ctx.Projetos.OrderBy(p => p.nome).Select(p => new SelectListItem
            {
                Text = p.nome,
                Value = p.Id.ToString()
            });

            return View("Form");
        }

        [HttpPost]
        public IActionResult Novo(Requisito r)
        {
            if (ModelState.IsValid)
            {
                r.dataCadastro = DateTime.Now;

                ctx.Requisitos.Add(r);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", r);
            }
        }

        public IActionResult Editar(int id)
        {
            ViewData["Title"] = "Editar";

            ViewBag.Projetos = ctx.Projetos.OrderBy(p => p.nome).Select(p => new SelectListItem
            {
                Text = p.nome,
                Value = p.Id.ToString()
            });

            Requisito r = ctx.Requisitos.Find(id);

            if (r != null)
            {
                return View("Form", r);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Requisito r)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(r).Property(x => x.funcional).IsModified = true;
                ctx.Entry(r).Property(x => x.dataEntrega).IsModified = true;
                ctx.Entry(r).Property(x => x.descricao).IsModified = true;
                ctx.Entry(r).Property(x => x.observacoes).IsModified = true;
                ctx.Entry(r).Property(x => x.ProjetoId).IsModified = true;
                ctx.Entry(r).Property(x => x.dataEntrega).IsModified = true;

                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", r);
            }
        }

        public IActionResult Deletar(int id)
        {
            Requisito r = ctx.Requisitos.Find(id);

            if (r != null)
            {
                ctx.Requisitos.Remove(r);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
