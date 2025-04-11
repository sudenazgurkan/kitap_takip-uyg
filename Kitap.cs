using System;
using System.ComponentModel.DataAnnotations;

namespace KitapTakip.Models
{
    public class Kitap
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Ad { get; set; }

        [Required]
        [StringLength(200)]
        public string Yazar { get; set; }

        [Required]
        public string ISBN { get; set; }

        public string Aciklama { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public bool Okundu { get; set; }

        public int? SayfaSayisi { get; set; }

        public string YayinEvi { get; set; }

        public int? BaskiYili { get; set; }
    }
} 