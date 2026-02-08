using System.Windows;
using MyAiAgent;

namespace CommWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ITestDesignAgent _agent;

        public MainWindow(ITestDesignAgent agent)
        {
            InitializeComponent();
            _agent = agent;            
        }

        public async void Send_Click(object sender, RoutedEventArgs e)
        {
            SendButton.IsEnabled = false;
        }
    }
}