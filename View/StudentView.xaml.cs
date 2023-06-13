using System;
using System.Windows.Controls;
using Projekt_WPF_EF_PraktykiStudenckie.Model;
using Projekt_WPF_EF_PraktykiStudenckie.ViewModel;

namespace Projekt_WPF_EF_PraktykiStudenckie.View
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {
        static readonly ApplicationContext dbContext = new();
        readonly StudentViewModel context = new(dbContext);
        public StudentView()
        {
            InitializeComponent();

            DataContext = context;
        }
    }
}
