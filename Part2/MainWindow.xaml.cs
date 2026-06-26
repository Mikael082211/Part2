
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Part2
{
    public partial class MainWindow : Window
    {
        // ================= CORE =================
        private Chatbot bot = new Chatbot();
        private bool darkMode = true;
        private string userName = "";
        private bool nameEntered = false;

        // ================= TASKS =================
        private List<CyberTask> tasks = new List<CyberTask>();

        // ================= QUIZ =================
        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
        private int currentQuestion = 0;
        private int score = 0;

        public MainWindow()
        {
            InitializeComponent();

            AudioPlayer.PlayGreeting();
            LoadQuizQuestions();

            AddBotMessage("Hello!");
            AddBotMessage("Welcome to Cybersecurity Awareness Bot.");
            AddBotMessage("Please enter your name to begin.");
        }

        // ================= QUIZ LOAD =================
        private void LoadQuizQuestions()
        {
            quizQuestions.Add(new QuizQuestion("What is phishing?", "scam"));
            quizQuestions.Add(new QuizQuestion("Should you share passwords?", "no"));
            quizQuestions.Add(new QuizQuestion("What is malware?", "malicious software"));
            quizQuestions.Add(new QuizQuestion("What does VPN stand for?", "virtual private network"));
            quizQuestions.Add(new QuizQuestion("Should you click unknown links?", "no"));
        }

        // ================= SEND =================
        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                await SendMessage();
        }

        private async Task SendMessage()
        {
            string input = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
                return;

            AddUserMessage(input);
            txtUserInput.Clear();

            // ================= NAME ENTRY =================
            if (!nameEntered)
            {
                userName = input;
                nameEntered = true;

                txtStatus.Text = $" {userName} online";

                await Task.Delay(500);

                AddBotMessage($"Welcome {userName}!");
                AddBotMessage("Try: password, phishing, malware, privacy, or type 'quiz'");

                ActivityLog.Add("User logged in");
                return;
            }

            txtStatus.Text = " Bot typing...";
            await Task.Delay(600);

            // ================= QUIZ MODE =================
            if (CheckQuizAnswer(input))
            {
                txtStatus.Text = $" {userName} online";
                return;
            }

            if (input.ToLower().Contains("quiz"))
            {
                StartQuiz();
                txtStatus.Text = $" {userName} online";
                return;
            }

            // ================= CHATBOT =================
            string response = bot.GetResponse(input);
            AddBotMessage(response);

            ActivityLog.Add($"User: {input}");

            txtStatus.Text = $" {userName} online";
        }

        // ================= MESSAGES =================
        private void AddUserMessage(string message)
        {
            ChatPanel.Children.Add(CreateBubble(message, "#6FFFE9", Brushes.Black, HorizontalAlignment.Right));
        }

        private void AddBotMessage(string message)
        {
            ChatPanel.Children.Add(CreateBubble(message, "#2C3E50", Brushes.White, HorizontalAlignment.Left));
            ChatScrollViewer.ScrollToEnd();
        }

        private Border CreateBubble(string message, string color, Brush textColor, HorizontalAlignment align)
        {
            return new Border
            {
                Background = (Brush)new BrushConverter().ConvertFromString(color),
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(10),
                Margin = new Thickness(5),
                HorizontalAlignment = align,
                MaxWidth = 300,
                Child = new TextBlock
                {
                    Text = message,
                    Foreground = textColor,
                    TextWrapping = TextWrapping.Wrap
                }
            };
        }

        // ================= TASKS =================
        private void AddTask(string title, string description)
        {
            tasks.Add(new CyberTask
            {
                Title = title,
                Description = description,
                ReminderDate = DateTime.Now.AddDays(1),
                IsCompleted = false
            });

            ActivityLog.Add($"Task Added: {title}");
            AddBotMessage($" Task added: {title}");
        }

        // ================= QUIZ =================
        private void StartQuiz()
        {
            currentQuestion = 0;
            score = 0;

            AddBotMessage(" Quiz Started!");
            AddBotMessage(quizQuestions[currentQuestion].Question);

            ActivityLog.Add("Quiz started");
        }

        private bool CheckQuizAnswer(string input)
        {
            if (currentQuestion >= quizQuestions.Count)
                return false;

            string correct = quizQuestions[currentQuestion].Answer.ToLower();

            if (input.ToLower().Trim() == correct)
            {
                score++;
                AddBotMessage("Correct!");
            }
            else
            {
                AddBotMessage($" Wrong. Answer: {correct}");
            }

            currentQuestion++;

            if (currentQuestion < quizQuestions.Count)
            {
                AddBotMessage(quizQuestions[currentQuestion].Question);
            }
            else
            {
                AddBotMessage($" Quiz Complete! Score: {score}/{quizQuestions.Count}");
                ActivityLog.Add($"Quiz finished: {score}/{quizQuestions.Count}");
            }

            return true;
        }

        // ================= BUTTONS =================
        private void btnQuiz_Click(object sender, RoutedEventArgs e)
        {
            StartQuiz();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTask("Task", txtUserInput.Text);
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            foreach (var log in ActivityLog.Logs)
                AddBotMessage(log);
        }

        // ================= THEME =================
        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            if (darkMode)
            {
                Background = Brushes.WhiteSmoke;
                darkMode = false;
            }
            else
            {
                Background = (Brush)new BrushConverter().ConvertFromString("#081416");
                darkMode = true;
            }
        }
    }
}
