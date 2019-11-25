using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoWebV1.Models;

namespace TrabalhoWebV1
{
    public class AppContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedors { get; set; }
        public DbSet<DesenvolvedorProjeto> DesenvolvedorProjetos { get; set; }
        public DbSet<DesenvolvedorRequisito> DesenvolverdorRequisitos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Requisito> Requisitos { get; set; }

        public AppContext(DbContextOptions o) : base(o)
        {

        }
    }
}
