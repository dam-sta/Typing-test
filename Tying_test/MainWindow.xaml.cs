using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tying_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch stopwatch = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void SendText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textboxForUserToDropTextIn.Text))
            {
                MessageBox.Show("Type something");
            }
            else
            {
                string trimmedText = string.Join("\r\n", textboxForUserToDropTextIn.Text.Split('\n').Select(s => s.Trim()));
                typingTestText.Text = trimmedText;
                textboxForUserToDropTextIn.Text = "";
                textboxForUserToDropTextIn.Visibility = Visibility.Collapsed;
                btnGenerateTypingTest.Content = "Stop the typing test";
                typingTestText.Visibility = Visibility.Visible;
                typingTest.Visibility = Visibility.Visible;
                btnGenerateTypingTest.Visibility = Visibility.Collapsed;
                btnStopWritingTest.Visibility = Visibility.Visible;
                typingTest.Focus();
                stopwatch.Restart();
            }
        }

        private void TypingTestTypedCharacter(object sender, KeyEventArgs e)
        {
            if (typingTest.Text.Length > typingTestText.Text.Length)
            {
                return;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.V)
                {
                    btnStopWritingTest.Content = "hi";

                }
            }

            string textSoFar = "";
            var isLengthZero = typingTest.Text.Length > 0;

            if (typingTest.Text == typingTestText.Text)
            {
                stopwatch.Stop();
                int lengthOfText = typingTest.Text.Length;
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:0}:{1:00}", ts.Minutes, ts.Seconds);
                string elapsedTimeInSeconds = String.Format("{00}", ts.Seconds);
                double wpm = Math.Round(((lengthOfText / 5) / (double.Parse(elapsedTimeInSeconds) / 60)), 2);
                MessageBox.Show($"Your WPM: {wpm}\nYou were typing for: {elapsedTime}");
                StopTypingTest(sender, e);
                return;
            }

            if (isLengthZero)
            {
                textSoFar = typingTestText.Text.Substring(0, typingTest.Text.Length);
            }

            if (typingTest.Text != textSoFar && isLengthZero)
            {
                typingTest.Foreground = Brushes.Red;
            }
            else if (isLengthZero)
            {
                typingTest.Foreground = Brushes.Green;
            }
        }

        private void AllowKeyPress(object sender, KeyEventArgs e)
        {
            if (typingTest.Text.Length >= typingTestText.Text.Length && e.Key != Key.Back)
            {
                e.Handled = true;
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                e.Handled = true;
            }
        }

        private void StopTypingTest(object sender, RoutedEventArgs e)
        {
            btnGenerateTypingTest.Content = "Send text";
            textboxForUserToDropTextIn.Text = typingTestText.Text;
            typingTestText.Text = "";
            typingTest.Text = "";
            textboxForUserToDropTextIn.Visibility = Visibility.Visible;
            typingTestText.Visibility = Visibility.Collapsed;
            typingTest.Visibility = Visibility.Collapsed;
            btnGenerateTypingTest.Visibility = Visibility.Visible;
            btnStopWritingTest.Visibility = Visibility.Collapsed;
        }

        private void CheckIfAllowed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) ==
      ModifierKeys.Control)
            {
                e.Handled = true;
            }
        }
    }
}
