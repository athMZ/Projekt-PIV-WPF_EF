using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Year { get; set; }

        public SupervisorUniversity? SupervisorUniversity { get; set; }
        public SupervisorCompany? SupervisorCompany { get; set; }

        public override string ToString() => $"{FirstName}, {LastName}, {StudentId}, {Email}, {Year}";

    }
}