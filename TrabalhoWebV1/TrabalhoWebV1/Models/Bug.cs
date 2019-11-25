using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWebV1.Models
{
    public class Bug
    {
        public int Id { get; set; }

        public int desenvolvedorCriadorId { get; set; }
        [ForeignKey("desenvolvedorCriadorId")]
        public Desenvolvedor DesenvolvedorCriador { get; set; }

        public int desenvolvedorResolvedorId { get; set; }
        [ForeignKey("desenvolvedorResolvedorId")]
        public Desenvolvedor DesenvolvedorResolvedor { get; set; }

        public int requisitoId { get; set; }
        public Requisito Requisito { get; set; }

        public String descricao { get; set; }
        public String prioridade { get; set; }
        public DateTime dataCadastro { get; set; }
        public bool resolvido { get; set; }
    }
}
