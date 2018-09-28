using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspClassMgt.Models
{
    [Table("Curso")]
    public partial class Curso
    {
        [Key]
        public int IdCurso { get; set; }

        public int instituicaoCurso { get; set; }

        public string NomeCurso { get; set; }

        public string CargaHoraria { get; set; }

        public int CursoProfessor { get; set; }

        public Professor CursoProfessorO { get; set; }

    }
}