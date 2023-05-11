using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool player1 = true;
        int clickcount = 0;
        int countWinsX;
        int countWinsO;
        List<Button> buttons = null;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button>
            {
                Button1, Button2, Button3, Button4, Button5,
                Button6, Button7, Button8, Button9
            };
        }
        public string FillButton()
        {
            if (player1)
            {
                return "X";
            }
            return "O";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clickcount++;
            Button button = sender as Button;
            button.Content = FillButton();
            button.IsEnabled = false;
            if (CheckIfWon() || clickcount == 9)
            {
                bool IsDraw = false;
                WinnerText.IsEnabled = true;
                WinnerText.Visibility = Visibility.Visible;
                foreach (Button bt in buttons)
                {
                    bt.IsEnabled = false;
                }
                if (clickcount == 9 && !CheckIfWon())
                {
                    WinnerText.Content = "Unentschieden";
                    IsDraw = true;
                }
                else
                {
                    WinnerText.Content = FillButton() + " hat gewonnen";
                }

                if(!IsDraw)
                {
                    if (FillButton() == "X")
                    {
                        countWinsX++;
                        WinsX.Content = countWinsX;
                    }
                    else
                    {
                        countWinsO++;
                        WinsO.Content = countWinsO;
                    }
                }

                NewGame.Visibility = Visibility.Visible;
            }
            player1 = !player1;
        }

        private bool CheckIfWon()
        {
            if (Button1.Content == Button2.Content && Button2.Content == Button3.Content && (Button1.Content == "X" || Button1.Content == "O"))
                return true;
            if (Button4.Content == Button5.Content && Button5.Content == Button6.Content && (Button4.Content == "X" || Button4.Content == "O"))
                return true;
            if (Button7.Content == Button8.Content && Button8.Content == Button9.Content && (Button7.Content == "X" || Button7.Content == "O"))
                return true;
            if (Button7.Content == Button4.Content && Button4.Content == Button1.Content && (Button7.Content == "X" || Button7.Content == "O"))
                return true;
            if (Button8.Content == Button5.Content && Button5.Content == Button2.Content && (Button8.Content == "X" || Button8.Content == "O"))
                return true;
            if (Button9.Content == Button6.Content && Button6.Content == Button3.Content && (Button9.Content == "X" || Button9.Content == "O"))
                return true;
            if (Button7.Content == Button5.Content && Button5.Content == Button3.Content && (Button7.Content == "X" || Button7.Content == "O"))
                return true;
            if (Button9.Content == Button5.Content && Button5.Content == Button1.Content && (Button9.Content == "X" || Button9.Content == "O"))
                return true;

            return false;

            
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame.Visibility = Visibility.Hidden;
            foreach (Button bt in buttons)
            {
                bt.Content = null;
                bt.IsEnabled = true;
            }
            clickcount = 0;
            WinnerText.IsEnabled = false;
            WinnerText.Visibility = Visibility.Hidden;
            WinnerText.Content = null;
        }
    }
}
