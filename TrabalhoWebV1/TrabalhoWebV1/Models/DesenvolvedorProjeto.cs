using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWebV1.Models
{
    public class DesenvolvedorProjeto
    {
        public int Id { get; set; }
        public int DesenvolvedorId { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
