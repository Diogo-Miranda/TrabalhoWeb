using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWebV1.Controllers
{
    public class DashboardController : Controller
    {
        private AppContext ctx;

        public DashboardController(AppContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Desenvolvedores = ctx.Desenvolvedors;
            ViewBag.Projetos = ctx.Projetos;
            ViewBag.Requisitos = ctx.Requisitos;
            ViewBag.Bugs = ctx.Bugs;

            return View();
        }
    }
}
