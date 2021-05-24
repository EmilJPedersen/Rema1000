using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rema1000.Models
{
    public class Leverandør
    {
        public int Id { get; set; } //PrimaryKey
        public String Navn { get; set; }
        public String Adresse { get; set; }
        public String Postnr { get; set; }
        public String Kontakperson { get; set; }
        public String Email { get; set; }
        public String Telefon { get; set; }
    }
}
