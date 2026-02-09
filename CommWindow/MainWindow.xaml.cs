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
        private readonly TestDesignPrompt _prompts;
        private readonly FieldSpecification _fieldSpec;

        public MainWindow(ITestDesignAgent agent, TestDesignPrompt prompt, FieldSpecification fieldSpec)
        {
            InitializeComponent();
            _agent = agent;            
            _prompts = prompt;
            _fieldSpec = fieldSpec;
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

                var result = await _agent.GenerateAsync(_fieldSpec, _prompts.userPrompt);

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