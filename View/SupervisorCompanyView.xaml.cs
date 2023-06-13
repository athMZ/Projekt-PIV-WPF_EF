using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekt_WPF_EF_PraktykiStudenckie.Model;
using Projekt_WPF_EF_PraktykiStudenckie.ViewModel;

namespace Projekt_WPF_EF_PraktykiStudenckie.View
{
    /// <summary>
    /// Interaction logic for SupervisorCompanyView.xaml
    /// </summary>
    public partial class SupervisorCompanyView : UserControl
    {
        static readonly ApplicationContext _dbContext = new();
        readonly SupervisorCompanyViewModel _context = new(_dbContext);

        public SupervisorCompanyView()
        {
            InitializeComponent();

            DataContext = _context;
        }

    }
}
