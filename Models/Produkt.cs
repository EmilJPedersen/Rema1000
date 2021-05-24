using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rema1000.Models
{
    public class Produkt
    {
        public int Id { get; set; } //PrimaryKey
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public float Enhed { get; set; }
        public int Mængde { get; set; }
        public float Pris { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; } //ForeignKey
        public int Lager { get; set; }
        public int LeverandørId { get; set; }
        public Leverandør Leverandør { get; set; } //ForeignKey
    }
}
