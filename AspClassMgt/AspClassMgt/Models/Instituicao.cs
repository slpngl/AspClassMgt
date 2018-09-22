using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspClassMgt.Models
{
    [Table("Instituicao")]
    public class Instituicao
    {
        [Key]
        public int IdInstituicao { get; set; }

        public string nomeInstituicao { get; set; }
        public string lgnInstituicao { get; set; }
        public string snhInstituicao { get; set; }
    }
}