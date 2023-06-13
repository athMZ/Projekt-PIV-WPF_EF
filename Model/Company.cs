using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [StringLength(10)]
        public string NipNumber { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public virtual ICollection<Internship> Internships { get; set; } = new List<Internship>();

        public override string ToString() => $"{Name}, {NipNumber}, {Phone}";
    }
}