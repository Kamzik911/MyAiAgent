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
        private readonly FieldSpecification _fieldSpecs;

        public MainWindow(ITestDesignAgent agent, FieldSpecification fieldSpecs)
        {
            InitializeComponent();
            _agent = agent;
            _fieldSpecs = fieldSpecs;
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

                var result = await _agent.GenerateAsync(_fieldSpecs);
                

                OutputTextBox.Text = JsonSerializer.Serialize(result, new JsonSerializerOptions
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