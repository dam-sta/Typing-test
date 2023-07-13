using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if ((string)btnGenerateTypingTest.Content == "Send text")
            {
                if (string.IsNullOrEmpty(textboxForUserToDropTextIn.Text))
                {
                    MessageBox.Show("Type something");
                }
                else
                {
                    typingTestText.Text = textboxForUserToDropTextIn.Text;
                    textboxForUserToDropTextIn.Text = "";
                    textboxForUserToDropTextIn.Visibility = Visibility.Collapsed;
                    btnGenerateTypingTest.Content = "Stop the typing test";
                    btnGenerateTypingTest.VerticalAlignment = VerticalAlignment.Bottom;
                    btnGenerateTypingTest.HorizontalAlignment = HorizontalAlignment.Center;
                    btnGenerateTypingTest.Margin = new Thickness(0);
                    typingTestText.Visibility = Visibility.Visible;
                    typingTest.Visibility = Visibility.Visible;

                }
            }
            else
            {
                btnGenerateTypingTest.Content = "Send text";
                textboxForUserToDropTextIn.Text = typingTestText.Text;
                typingTestText.Text = "";
                typingTest.Text = "";
                textboxForUserToDropTextIn.Visibility = Visibility.Visible;
                btnGenerateTypingTest.VerticalAlignment = VerticalAlignment.Bottom;
                btnGenerateTypingTest.HorizontalAlignment = HorizontalAlignment.Center;
                btnGenerateTypingTest.Margin = new Thickness(0);
                typingTestText.Visibility = Visibility.Collapsed;
                typingTest.Visibility = Visibility.Collapsed;
            }

        }
    }
}
