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
        private readonly IQuestionsToAgent _agent;
        private readonly FieldSpecification _fieldSpec;

        public MainWindow(IQuestionsToAgent agent)
        {
            InitializeComponent();
            _agent = agent;
            _fieldSpec = new FieldSpecification();
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

                var result = await _agent.EmailQuestionGenerateAsync(_fieldSpec, prompt);


                OutputTextBox.Text = result.Markdown;
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