using System;
using Projekt_WPF_EF_PraktykiStudenckie.Model;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;

namespace Projekt_WPF_EF_PraktykiStudenckie.ViewModel
{
    public class CompanyViewModel : BaseViewModel
    {
        private readonly ApplicationContext _dbContext;
        private Company _company;
        private ObservableCollection<Company> _companies;
        private Company _selectedItem;

        public CompanyViewModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _company = new Company()
            {
                Name = "Company",
                NipNumber = "1234567890",
                Phone = "123456789"
            };
            _companies = new ObservableCollection<Company>(_dbContext.Companies);
        }

        public override void RefreshTable()
        {
            _companies = new ObservableCollection<Company>(_dbContext.Companies);
            OnPropertyChanged(nameof(Companies));
        }

        public override void InsertToTable()
        {
            try
            {
                _company.Id = _dbContext.Companies.GetNextId();

                _dbContext.Companies.Add(_company);
                _dbContext.SaveChanges();

                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Insert failed! Check data.");
            }
        }

        public override void UpdateModel()
        {
            _dbContext.UpdateRange(_companies);
            _dbContext.SaveChanges();

            RefreshTable();
        }

        public override void DeleteFromTable()
        {
            try
            {
                if (_selectedItem != null) _dbContext.Companies.Remove(_selectedItem);
                _dbContext.SaveChanges();
                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Delete failed! Check tables.");

            }
        }

        public Company? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Company Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value;
                OnPropertyChanged();
            }
        }

        public string CompanyName
        {
            get => _company.Name;
            set
            {
                _company.Name = value;
                OnPropertyChanged();
            }
        }

        public int CompanyId
        {
            get => _company.Id;
            set
            {
                _company.Id = value;
                OnPropertyChanged();
            }
        }

        public string NipNumber
        {
            get => _company.NipNumber;
            set
            {
                _company.NipNumber = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _company.Phone;
            set
            {
                _company.Phone = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Internship> Internships
        {
            get => (ObservableCollection<Internship>)_company.Internships;
            set => _company.Internships = value;
        }
    }
}