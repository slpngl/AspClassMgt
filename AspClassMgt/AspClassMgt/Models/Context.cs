using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspClassMgt.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Instituicao> Instituicao { get; set; }

    }
}