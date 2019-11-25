using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWebV1.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        public String nome { get; set; }

        public DateTime dataEntrega { get; set; }

        public String solicitante { get; set; }

        public IEnumerable<DesenvolvedorProjeto> DesenvolvedorProjetos { get; set; }
        public IEnumerable<Requisito> Requisitos { get; set; }
    }
}
