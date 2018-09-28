using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspClassMgt.Models
{
    [Table("Matricula")]
    public class Matricula
    {
        [Key]
        public int IdMatricula { get; set; }

        public int InstituicaoIDMatricula  { get; set; }

        public int AlunoIDMatricula { get; set; }

        public int CursoIDMatricula { get; set; }

       
    }



}