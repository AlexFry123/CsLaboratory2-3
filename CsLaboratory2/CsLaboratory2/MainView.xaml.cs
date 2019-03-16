using System.Windows.Navigation;

namespace CsLaboratory2
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : NavigationWindow
    {
        public MainView()
        {
            InitializeComponent();
            NavigationManager.NavigationWindow = this;
        }
    }
}
