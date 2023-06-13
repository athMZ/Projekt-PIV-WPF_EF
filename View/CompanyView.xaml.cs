using System.Windows.Controls;
using Projekt_WPF_EF_PraktykiStudenckie.Model;
using Projekt_WPF_EF_PraktykiStudenckie.ViewModel;

namespace Projekt_WPF_EF_PraktykiStudenckie.View
{
    /// <summary>
    /// Interaction logic for CompanyView.xaml
    /// </summary>
    public partial class CompanyView : UserControl
    {
        static readonly ApplicationContext dbContext = new();
        readonly CompanyViewModel context = new(dbContext);

        public CompanyView()
        {
            InitializeComponent();

            DataContext = context;
        }
    }
}
