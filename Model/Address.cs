using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public sealed class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int? Building { get; set; }
        public int? Flat { get; set; }

        public Company? Company { get; set; }

        public override string ToString() => $"{Id}, {City}, {PostalCode}, {Street}, {Building}, {Flat}";
    }
}