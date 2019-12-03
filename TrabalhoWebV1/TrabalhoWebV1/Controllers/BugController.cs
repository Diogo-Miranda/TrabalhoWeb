using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoWebV1.Models;

namespace TrabalhoWebV1.Controllers
{
    public class BugController : Controller
    {
        private AppContext ctx;

        public BugController(AppContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Bugs = ctx.Bugs;

            return View();
        }
        
        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo";

            ViewBag.Desenvolvedores = ctx.Desenvolvedors.OrderBy(d => d.nome).Select(d => new SelectListItem
            {
                Text = d.nome,
                Value = d.Id.ToString()
            });

            ViewBag.Requisitos = ctx.Requisitos.OrderBy(r => r.descricao).Select(r => new SelectListItem
            {
                Text = r.descricao,
                Value = r.Id.ToString()
            });

            return View("Form");
        }

        [HttpPost]
        public IActionResult Novo(Bug bug)
        {
            if (ModelState.IsValid)
            {
                bug.dataCadastro = DateTime.Now;

                ctx.Bugs.Add(bug);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", bug);
            }
        }

        public IActionResult Editar(int id)
        {
            ViewData["Title"] = "Editar";

            Bug bug = ctx.Bugs.Find(id);


            ViewBag.Desenvolvedores = ctx.Desenvolvedors.OrderBy(a => a.nome).Select(d => new SelectListItem
            {
                Text = d.nome,
                Value = d.Id.ToString()
            }) ;

            ViewBag.Requisitos = ctx.Requisitos.OrderBy(a => a.descricao).Select(r => new SelectListItem
            {
                Text = r.descricao,
                Value = r.Id.ToString()
            });

            if (bug != null)
            {
                return View("Form", bug);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Bug bug)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(bug).Property(b => b.desenvolvedorCriadorId).IsModified = true;
                ctx.Entry(bug).Property(b => b.desenvolvedorResolvedorId).IsModified = true;
                ctx.Entry(bug).Property(b => b.requisitoId).IsModified = true;
                ctx.Entry(bug).Property(b => b.resolvido).IsModified = true;
                ctx.Entry(bug).Property(b => b.descricao).IsModified = true;
                ctx.Entry(bug).Property(b => b.prioridade).IsModified = true;

                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", bug);
            }
        }

        public IActionResult Del(int id)
        {
            Bug bug = ctx.Bugs.Find(id);

            if (bug != null)
            {
                ctx.Bugs.Remove(bug);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
