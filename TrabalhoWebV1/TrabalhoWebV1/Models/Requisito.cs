using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWebV1.Models
{
    public class Requisito
    {
        public int Id { get; set; }
        public DateTime dataCadastro { get; set; }
        public String descricao { get; set; }
        public String observacoes { get; set; }
        public DateTime dataEntrega { get; set; }
        public bool funcional { get; set; }


        public int ProjetoId { get; set; }
        public Projeto projeto { get; set; }

        public IEnumerable<DesenvolvedorRequisito> DesenvolvedorRequisitos { get; set; }
        public IEnumerable<Bug> Bugs { get; set; }
    }
}
