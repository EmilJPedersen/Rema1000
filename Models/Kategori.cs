using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rema1000.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; } //PrimaryKey
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
    }
}
