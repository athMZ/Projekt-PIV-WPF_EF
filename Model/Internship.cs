using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public sealed class Internship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public Company Company { get; set; }

        public Student Student { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Responsibilities { get; set; } = string.Empty;

        public override string ToString() => $"{Start} {End} {Responsibilities}";
    }
}