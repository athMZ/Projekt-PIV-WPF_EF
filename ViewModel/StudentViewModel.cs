using Projekt_WPF_EF_PraktykiStudenckie.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Projekt_WPF_EF_PraktykiStudenckie.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        private readonly ApplicationContext _dbContext;
        private Student _student;
        private ObservableCollection<Student> _students;
        private Student? _selectedItem;

        public StudentViewModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _student = new Student()
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                StudentId = "s12345",
                Email = "jan.kowalski@mail.com",
                Year = 3
            };
            _students = new ObservableCollection<Student>(_dbContext.Students);
        }

        public override void RefreshTable()
        {
            _students = new ObservableCollection<Student>(_dbContext.Students);

            OnPropertyChanged(nameof(Students));
        }

        public override void UpdateModel()
        {
            _dbContext.UpdateRange(_students);
            _dbContext.SaveChanges();
        }

        public override void InsertToTable()
        {
            try
            {
                _student.Id = _dbContext.Students.GetNextId();

                _dbContext.Students.Add(_student);
                _dbContext.SaveChanges();

                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Insert failed! Check data.");
            }
        }

        public override void DeleteFromTable()
        {
            try
            {
                if (_selectedItem != null) _dbContext.Students.Remove(_selectedItem);
                _dbContext.SaveChanges();
                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Delete failed! Check tables.");
            }
        }

        public Student? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Student Student
        {
            get => _student;
            set { _student = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set { _students = value; OnPropertyChanged(); }
        }

        public string FirstName
        {
            get => _student.FirstName;
            set { _student.FirstName = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => _student.LastName;
            set { _student.LastName = value; OnPropertyChanged(); }
        }

        public string StudentId
        {
            get => _student.StudentId;
            set { _student.StudentId = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _student.Email;
            set { _student.Email = value; OnPropertyChanged(); }
        }

        public int Year
        {
            get => _student.Year;
            set { _student.Year = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SupervisorCompany> CompanySupervisors => new(_dbContext.CompanySupervisors);
        public ObservableCollection<SupervisorUniversity> UniversitySupervisors => new(_dbContext.UniversitySupervisors);

        public SupervisorCompany SelectedSupervisorCompany
        {
            get => _student.SupervisorCompany;
            set { _student.SupervisorCompany = value; OnPropertyChanged(); }
        }

        public SupervisorUniversity SelectedSupervisorUniversity
        {
            get => _student.SupervisorUniversity;
            set { _student.SupervisorUniversity = value; OnPropertyChanged(); }
        }
    }
}