using Projekt_WPF_EF_PraktykiStudenckie.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Projekt_WPF_EF_PraktykiStudenckie.ViewModel
{
    public class InternshipViewModel : BaseViewModel
    {
        private readonly ApplicationContext _dbContext;
        private readonly Internship _internship;
        private ObservableCollection<Internship> _internships;
        private Internship? _selectedItem;

        public InternshipViewModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _internship = new Internship();
            _internships = new ObservableCollection<Internship>(_dbContext.Internships);
        }

        public override void RefreshTable()
        {
            _internships = new ObservableCollection<Internship>(_dbContext.Internships);
            OnPropertyChanged(nameof(Internships));
        }

        public override void UpdateModel()
        {
            _dbContext.UpdateRange(_internships);
            _dbContext.SaveChanges();

            RefreshTable();
        }

        public override void InsertToTable()
        {
            try
            {
                _internship.Id = _dbContext.Internships.GetNextId();

                _dbContext.Internships.Add(_internship);
                _dbContext.SaveChanges();

                RefreshTable();
            }
            catch (Exception e)
            {
                MessageBox.Show("Insert failed! Check data.\n" + e.Message);
            }
        }

        public override void DeleteFromTable()
        {
            try
            {
                if (_selectedItem != null) _dbContext.Internships.Remove(_internship);
                _dbContext.SaveChanges();
                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Delete failed! Check tables.");
            }
        }

        public Internship? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public string Responsibilities
        {
            get => _internship.Responsibilities;
            set
            {
                _internship.Responsibilities = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get => _internship.Start;
            set
            {
                _internship.Start = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get => _internship.End;
            set
            {
                _internship.End = value;
                OnPropertyChanged();
            }
        }

        public Company SelectedCompany
        {
            get => _internship.Company;
            set
            {
                _internship.Company = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get => _internship.Student;
            set
            {
                _internship.Student = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Internship> Internships
        {
            get => _internships;
            set
            {
                _internships = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Company> Companies => new(_dbContext.Companies);

        public ObservableCollection<Student> Students => new(_dbContext.Students);
    }
}