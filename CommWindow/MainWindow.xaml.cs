using System.Windows;
using MyAiAgent.Interfaces;

namespace CommWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        private readonly IChatService _chat;

        public MainWindow(IChatService chat)
        {
            InitializeComponent();
            _chat = chat;
        }

        public async void QuestionSendButton(object sender, RoutedEventArgs e)
        {
            var query = InputTextBox.Text?.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                OutputTextBox.Text = "Zadejte dotaz, prosím.";
                return;
            }
            SendButton.IsEnabled = false;
            OutputTextBox.Text = "Odesílám dotaz...";
            try
            {
                var answer = await _chat.AskAsync(query);
                OutputTextBox.Text = answer;
            }        
            catch (Exception ex)
            {
                OutputTextBox.Text = ex.Message;
            }
            finally
            {
                SendButton.IsEnabled = true;
            }

        }
    }
}