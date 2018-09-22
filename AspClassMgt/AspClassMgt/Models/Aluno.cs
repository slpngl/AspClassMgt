using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspClassMgt.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }

        public int instituicaoAluno { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }
    }
}