using Projekt_WPF_EF_PraktykiStudenckie.Command;
using Projekt_WPF_EF_PraktykiStudenckie.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Projekt_WPF_EF_PraktykiStudenckie.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private readonly ApplicationContext _dbContext;

        public event PropertyChangedEventHandler? PropertyChanged;

        private ICommand _updateTableCommand;
        private ICommand _insertToTableCommand;
        private ICommand _deleteFromTableCommand;

        public abstract void RefreshTable();

        public abstract void UpdateModel();

        public abstract void InsertToTable();

        public abstract void DeleteFromTable();

        public ICommand UpdateTableCommand => _updateTableCommand ??= new UpdateTableCommand(this);

        public ICommand InsertToTableCommand => _insertToTableCommand ??= new InsertToTableCommand(this);

        public ICommand DeleteFromTableCommand => _deleteFromTableCommand ??= new DeleteFromTableCommand(this);


        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


    }
}