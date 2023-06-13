using Projekt_WPF_EF_PraktykiStudenckie.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Projekt_WPF_EF_PraktykiStudenckie.ViewModel
{
    public class SupervisorUniversityViewModel : BaseViewModel
    {
        private readonly ApplicationContext _dbContext;
        private readonly SupervisorUniversity _supervisorUniversity;
        private ObservableCollection<SupervisorUniversity> _supervisorUniversityUniversities;
        private SupervisorUniversity? _selectedItem;

        public SupervisorUniversityViewModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _supervisorUniversity = new SupervisorUniversity()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "j.d@mail.com",
                Faculty = "XYZ"
            };
            _supervisorUniversityUniversities = new ObservableCollection<SupervisorUniversity>(_dbContext.UniversitySupervisors);
        }

        public override void RefreshTable()
        {
            _supervisorUniversityUniversities = new ObservableCollection<SupervisorUniversity>(_dbContext.UniversitySupervisors);
            OnPropertyChanged(nameof(SupervisorsUniversity));
        }

        public override void UpdateModel()
        {
            _dbContext.UpdateRange(_supervisorUniversityUniversities);
            _dbContext.SaveChanges();

            RefreshTable();
        }

        public override void InsertToTable()
        {
            try
            {
                _dbContext.UniversitySupervisors.Add(_supervisorUniversity);
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
                if (_selectedItem != null) _dbContext.UniversitySupervisors.Remove(_supervisorUniversity);
                _dbContext.SaveChanges();
                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Delete failed! Check tables.");
            }
        }

        public SupervisorUniversity? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SupervisorUniversity> SupervisorsUniversity
        {
            get => _supervisorUniversityUniversities;
            set
            {
                _supervisorUniversityUniversities = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _supervisorUniversity.FirstName;
            set
            {
                _supervisorUniversity.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _supervisorUniversity.LastName;
            set
            {
                _supervisorUniversity.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _supervisorUniversity.Email;
            set
            {
                _supervisorUniversity.Email = value;
                OnPropertyChanged();
            }
        }

        public string Faculty
        {
            get => _supervisorUniversity.Faculty;
            set
            {
                _supervisorUniversity.Faculty = value;
                OnPropertyChanged();
            }
        }
    }
}