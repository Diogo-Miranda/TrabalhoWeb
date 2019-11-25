using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWebV1.Models
{
    public class DesenvolvedorRequisito
    {
        public int Id { get; set; }
        public int DesenvolvedorId { get; set; }
        public int RequisitoId { get; set; }
        public Requisito Requisito { get; set; }

    }
}
