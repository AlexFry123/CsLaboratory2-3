using System.Windows.Controls;


namespace CsLaboratory2
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Page
    {
        internal ResultWindow(Person user)
        {
            InitializeComponent();
            DataContext = new ResultViewModel(user);
        }
    }
}
