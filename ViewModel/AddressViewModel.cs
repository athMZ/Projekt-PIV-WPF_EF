using Projekt_WPF_EF_PraktykiStudenckie.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Projekt_WPF_EF_PraktykiStudenckie.ViewModel
{
    public class AddressViewModel : BaseViewModel
    {
        private readonly ApplicationContext _dbContext;
        private Address _address;
        private ObservableCollection<Address> _addresses;
        private Address? _selectedItem;

        public AddressViewModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _address = new Address()
            {
                Building = 1,
                City = "Warszawa",
                Flat = 1,
                PostalCode = "00-000",
                Street = "Koszykowa"
            };
            _addresses = new ObservableCollection<Address>(_dbContext.Addresses);
        }

        public override void RefreshTable()
        {
            _addresses = new ObservableCollection<Address>(_dbContext.Addresses);
            OnPropertyChanged(nameof(Addresses));
        }

        public override void UpdateModel()
        {
            _dbContext.UpdateRange(_addresses);
            _dbContext.SaveChanges();

            RefreshTable();
        }

        public override void InsertToTable()
        {
            try
            {
                _address.Id = _dbContext.Addresses.GetNextId();

                _dbContext.Addresses.Add(_address);
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
                if (_selectedItem != null) _dbContext.Addresses.Remove(_selectedItem);
                _dbContext.SaveChanges();
                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Delete failed! Check tables.");
            }
        }

        public Address? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Address Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Address> Addresses
        {
            get => _addresses;
            set
            {
                _addresses = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get => _address.City;
            set
            {
                _address.City = value;
                OnPropertyChanged();
            }
        }

        public string PostalCode
        {
            get => _address.PostalCode;
            set
            {
                _address.PostalCode = value;
                OnPropertyChanged();
            }
        }

        public string Street
        {
            get => _address.Street;
            set
            {
                _address.Street = value;
                OnPropertyChanged();
            }
        }

        public int? Building
        {
            get => _address.Building;
            set
            {
                _address.Building = value;
                OnPropertyChanged();
            }
        }

        public int? Flat
        {
            get => _address.Flat;
            set
            {
                _address.Flat = value;
                OnPropertyChanged();
            }
        }

        public Company Company
        {
            get => _address.Company;
            set
            {
                _address.Company = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Company> Companies => new(_dbContext.Companies);

        public Company? SelectedCompany
        {
            get => _address.Company;
            set
            {
                _address.Company = value;
                OnPropertyChanged();
            }
        }
    }
}