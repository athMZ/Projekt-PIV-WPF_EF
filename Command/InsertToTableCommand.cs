using System;
using System.Windows.Input;
using Projekt_WPF_EF_PraktykiStudenckie.ViewModel;

namespace Projekt_WPF_EF_PraktykiStudenckie.Command;

public class InsertToTableCommand : ICommand
{
    private readonly BaseViewModel _viewModel;

    public InsertToTableCommand(BaseViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        _viewModel.InsertToTable();
    }

    public event EventHandler? CanExecuteChanged;
}