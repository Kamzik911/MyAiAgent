using System.Linq.Expressions;
using System.Text.Json;
using System.Windows;
using MyAiAgent.Interfaces;
using MyAiAgent.Models;

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

        public async void QuestionSendButton(object sender, RoutedEventArgs e)
        {
            
            try
            {
                SendButton.IsEnabled = false;
                OutputTextBox.Text = "Working...";

                var prompt = InputTextBox.Text?.Trim();
                if (string.IsNullOrWhiteSpace(prompt))
                {
                    OutputTextBox.Text = "Please enter a request.";
                    return;
                }

                var result = await _agent.GenerateAsync(prompt);

                OutputTextBox.Text = result is string s ? s : JsonSerializer.Serialize(result, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
            }
            catch (Exception ex)
            {
                OutputTextBox.Text = ex.ToString();
            }
            finally
            {
                SendButton.IsEnabled = true;
            }
                       
        }
    }
}