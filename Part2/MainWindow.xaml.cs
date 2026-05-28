using System;
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
        Chatbot bot = new Chatbot();

        private bool darkMode = true;

        // STORE USER NAME
        private string userName = "";

        // CHECK IF NAME ENTERED
        private bool nameEntered = false;

        public MainWindow()
        {
            InitializeComponent();

            AudioPlayer.PlayGreeting();

            AddBotMessage(@"Hello! ");
            AddBotMessage("Welcome to the Cybersecurity Awareness Bot.");
            AddBotMessage("Please enter your name to begin.");
        }

        // SEND BUTTON
        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        // ENTER KEY
        private async void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await SendMessage();
            }
        }

        // SEND MESSAGE
        private async Task SendMessage()
        {
            string input = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            AddUserMessage(input);

            txtUserInput.Clear();

            // FIRST MESSAGE = USER NAME
            if (!nameEntered)
            {
                userName = input;
                nameEntered = true;

                txtStatus.Text = $"🟢 {userName} is online";

                await Task.Delay(800);

                AddBotMessage(
    $"Welcome {userName}! \n\n" +
    "I can help you learn about:\n\n" +
    "• Password Safety\n" +
    "• Phishing\n" +
    "• Safe Browsing\n" +
    "• Malware\n" +
    "• Data Privacy\n\n" +
    "Type a topic to begin.\n\n" +
    "Type your favourite topic for personalised tips.\n\n" +
    "Type EXIT to close the application."
);

                return;
            }

            // TYPING STATUS
            txtStatus.Text = "⌨ Bot is typing...";

            await Task.Delay(1200);

            string response = bot.GetResponse(input);

            AddBotMessage(response);

            txtStatus.Text = $"🟢 {userName} is online";
        }

        // USER MESSAGE
        private void AddUserMessage(string message)
        {
            Border bubble = CreateBubble(
                message,
                "#6FFFE9",
                Brushes.Black,
                HorizontalAlignment.Right,
                new Thickness(120, 10, 10, 10));

            ChatPanel.Children.Add(bubble);

            FadeAnimation(bubble);

            ChatScrollViewer.ScrollToEnd();
        }

        // BOT MESSAGE
        private void AddBotMessage(string message)
        {
            Border bubble = CreateBubble(
                message,
                "#2C3E50",
                Brushes.White,
                HorizontalAlignment.Left,
                new Thickness(10, 10, 120, 10));

            ChatPanel.Children.Add(bubble);

            FadeAnimation(bubble);

            ChatScrollViewer.ScrollToEnd();
        }

        // CREATE CHAT BUBBLE
        private Border CreateBubble(
            string message,
            string backgroundColor,
            Brush textColor,
            HorizontalAlignment alignment,
            Thickness margin)
        {
            Border bubble = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFromString(backgroundColor),
                CornerRadius = new CornerRadius(18),
                Padding = new Thickness(12),
                Margin = margin,
                HorizontalAlignment = alignment,
                MaxWidth = 300
            };

            StackPanel stack = new StackPanel();

            TextBlock text = new TextBlock
            {
                Text = message,
                Foreground = textColor,
                FontSize = 16,
                TextWrapping = TextWrapping.Wrap
            };

            TextBlock time = new TextBlock
            {
                Text = DateTime.Now.ToShortTimeString(),
                FontSize = 10,
                Foreground = Brushes.LightGray,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            stack.Children.Add(text);
            stack.Children.Add(time);

            bubble.Child = stack;

            return bubble;
        }

        // FADE ANIMATION
        private void FadeAnimation(UIElement element)
        {
            DoubleAnimation fade = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4)
            };

            element.BeginAnimation(OpacityProperty, fade);
        }

        // DARK/LIGHT MODE
        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            if (darkMode)
            {
                Background = Brushes.WhiteSmoke;
                darkMode = false;
                btnTheme.Content = "🌙";
            }
            else
            {
                Background = (Brush)new BrushConverter().ConvertFromString("#081416");
                darkMode = true;
                btnTheme.Content = "☀";
            }
        }
    }
}