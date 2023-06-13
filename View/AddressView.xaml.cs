using System.Windows.Controls;
using Projekt_WPF_EF_PraktykiStudenckie.Model;
using Projekt_WPF_EF_PraktykiStudenckie.ViewModel;

namespace Projekt_WPF_EF_PraktykiStudenckie.View
{
    /// <summary>
    /// Interaction logic for AddressView.xaml
    /// </summary>
    public partial class AddressView : UserControl
    {
        static readonly ApplicationContext _dbContext = new();
        readonly AddressViewModel _context = new(_dbContext);

        public AddressView()
        {
            InitializeComponent();

            DataContext = _context;
        }
    }

}
