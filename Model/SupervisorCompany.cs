using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public class SupervisorCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public Company Company { get; set; } = new Company();

        public virtual ICollection<Student> SupervisedStudents { get; set; } = new List<Student>();

        public override string ToString() => $"{FirstName}, {LastName}, {Email}, {Position}, {Phone}";

    }
}