using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CopaAPI.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
          : base("Contexto")
        {

        }

        public DbSet<Usuarios> usuarios { get; set; }
    }
}