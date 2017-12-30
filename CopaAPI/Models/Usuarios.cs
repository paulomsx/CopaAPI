using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CopaAPI.Models
{
    [Table("figurinhas.usuarios")]
    public class Usuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
    }
}