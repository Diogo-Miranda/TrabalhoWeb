using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWebV1.Models
{
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }
        public String nome { get; set; }
        public String email { get; set; }
        public String senha { get; set; }
        [NotMapped]
        public String tempSenha { get; set; }
        public bool adm { get; set; }

        [InverseProperty("desenvolvedorCriador")]
        public IEnumerable<Bug> bugCriados { get; set; }

        [InverseProperty("desenvolvedorResolvedor")]
        public IEnumerable<Bug> bugResolvidos { get; set; }
    }
}
