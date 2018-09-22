using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspClassMgt.Models
{
    [Table("Professor")]
    public partial class Professor
    {
        [Key]
        public int IdProfessor { get; set; }

        public int instituicaoProfessor { get; set; }

        public string NomeProfessor { get; set; }

        public string Formacao { get; set; }
    }
}