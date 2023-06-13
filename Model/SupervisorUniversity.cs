using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public class SupervisorUniversity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;

        public virtual ICollection<Student> SupervisedStudents { get; set; } = new List<Student>();

        public override string ToString() => $"{FirstName}, {LastName}, {Email}, {Faculty}";
    }
}