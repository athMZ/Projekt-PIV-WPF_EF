using Projekt_WPF_EF_PraktykiStudenckie.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Projekt_WPF_EF_PraktykiStudenckie.ViewModel
{
    public class SupervisorCompanyViewModel : BaseViewModel
    {
        private readonly ApplicationContext _dbContext;
        private SupervisorCompany _supervisorCompany;
        private ObservableCollection<SupervisorCompany> _supervisorCompanies;
        private SupervisorCompany? _selectedItem;

        public SupervisorCompanyViewModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _supervisorCompany = new SupervisorCompany()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "j.doe@mail.com",
                Phone = "123456789",
                Position = "CEO"
            };
            _supervisorCompanies = new ObservableCollection<SupervisorCompany>(_dbContext.CompanySupervisors);
        }

        public override void RefreshTable()
        {
            _supervisorCompanies = new ObservableCollection<SupervisorCompany>(_dbContext.CompanySupervisors);
            OnPropertyChanged(nameof(SupervisorCompanies));
        }

        public override void UpdateModel()
        {
            _dbContext.UpdateRange(_supervisorCompanies);
            _dbContext.SaveChanges();

            RefreshTable();
        }

        public override void InsertToTable()
        {
            try
            {
                _supervisorCompany.Id = _dbContext.CompanySupervisors.GetNextId();

                _dbContext.CompanySupervisors.Add(_supervisorCompany);
                _dbContext.SaveChanges();

                RefreshTable();
            }
            catch (Exception e)
            {
                MessageBox.Show("Insert failed! Check data.");
                throw e;
            }
        }

        public override void DeleteFromTable()
        {
            try
            {
                if (_selectedItem != null) _dbContext.CompanySupervisors.Remove(_selectedItem);
                _dbContext.SaveChanges();
                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Delete failed! Check tables.");
            }
        }

        public SupervisorCompany? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public SupervisorCompany SupervisorCompany
        {
            get => _supervisorCompany;
            set
            {
                _supervisorCompany = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SupervisorCompany> SupervisorCompanies
        {
            get => _supervisorCompanies;
            set
            {
                _supervisorCompanies = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _supervisorCompany.FirstName;
            set
            {
                _supervisorCompany.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _supervisorCompany.LastName;
            set
            {
                _supervisorCompany.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _supervisorCompany.Email;
            set
            {
                _supervisorCompany.Email = value;
                OnPropertyChanged();
            }
        }

        public string Position
        {
            get => _supervisorCompany.Position;
            set
            {
                _supervisorCompany.Position = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _supervisorCompany.Phone;
            set
            {
                _supervisorCompany.Phone = value;
                OnPropertyChanged();
            }
        }

        public Company SelectedCompany
        {
            get => _supervisorCompany.Company;
            set
            {
                _supervisorCompany.Company = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Company> Companies => new(_dbContext.Companies);
    }
}