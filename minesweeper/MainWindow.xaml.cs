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

namespace minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool firstGame; // is first game upon launching the game
        bool firstTurn; // is first turn (used to set mines after first click)
        dif difficulty;
        Board board;

        public enum dif
        {
            easy, medium, hard
        }

        SolidColorBrush unrevealedColor1 = new SolidColorBrush(Color.FromRgb(185, 221, 119));
        SolidColorBrush unrevealedColor2 = new SolidColorBrush(Color.FromRgb(162, 209, 73));
        SolidColorBrush revealedColor1 = new SolidColorBrush(Color.FromRgb(215, 184, 153));
        SolidColorBrush revealedColor2 = new SolidColorBrush(Color.FromRgb(229, 194, 159));
        public MainWindow()
        {
            InitializeComponent();
            difficulty = dif.easy;
            firstGame = true;
            firstTurn = true;
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            if(firstGame)
            {
                TextBlock bl = new TextBlock();
                bl.FontSize = 15;
                bl.Text = "Mines left: 0";
                bl.VerticalAlignment = VerticalAlignment.Center;
                bl.FontWeight = FontWeights.Bold;
                RegisterName("MinesCounter", bl);
                Header.Children.Add(bl);

                TextBlock tl = new TextBlock();
                tl.FontSize = 15;
                tl.Text = "Time: 0";
                tl.VerticalAlignment = VerticalAlignment.Center;
                tl.FontWeight = FontWeights.Bold;
                tl.Margin = new Thickness(30, 0, 0, 0);
                RegisterName("TimeCounter", tl);
                Header.Children.Add(tl);
                firstGame = false;
            }

            board = new Board(difficulty);
            firstTurn = true;
            (GameGrid.FindName("MinesCounter") as TextBlock).Text = $"Mines left: {board.Mines}";
            
            ShowGameBoard(difficulty);
        }

        private void ShowGameBoard(dif difficulty)
        {
            GameBoardSp.Children.RemoveRange(0, GameBoardSp.Children.Count); // Removes previous board
            
            // Setting width and length for things to look better
            double rectangleWidth;
            double rectangleHeight;
            if (difficulty == dif.easy)
            {
                rectangleWidth = 50;
                rectangleHeight = 50;
                Application.Current.MainWindow.Width = 650;
                Application.Current.MainWindow.Height = 550;
            }
            else if (difficulty == dif.medium)
            {
                rectangleWidth = 35;
                rectangleHeight = 35;
                Application.Current.MainWindow.Width = 750;
                Application.Current.MainWindow.Height = 650;
            }
            else
            {
                rectangleWidth = 33;
                rectangleHeight = 33;
                Application.Current.MainWindow.Width = 900;
                Application.Current.MainWindow.Height = 830;                
            }

            // Showing the board
            for (int i = 0; i < board.Rows; i++)
            {
                StackPanel rowSp = new StackPanel();
                rowSp.Orientation = Orientation.Horizontal;
                for (int j = 0; j < board.Cols; j++)
                {
                    Grid gr = new Grid();
                    Rectangle r = new Rectangle();
                    r.Width = rectangleWidth;
                    r.Height = rectangleHeight;
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                        r.Fill = unrevealedColor1;
                    else
                        r.Fill = unrevealedColor2;

                    gr.Name = $"r{i}c{j}";
                    if (FindName(gr.Name) != null)
                        UnregisterName(gr.Name);
                    RegisterName(gr.Name, gr);

                    gr.MouseLeftButtonDown += new MouseButtonEventHandler(FieldClick);

                    gr.Children.Add(r);
                    rowSp.Children.Add(gr);
                }
                GameBoardSp.Children.Add(rowSp);
            }
        }

        private void FieldClick(object sender, MouseButtonEventArgs e)
        {
            var gr = sender as Grid;
            if(firstTurn)
            {
                // TODO: set mines (extract row and column from gr.Name)
                firstTurn = false;
            }

            // TODO: make turn (reveal empty fields)
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var checkedBtn = sender as RadioButton;
            if (checkedBtn == null)
                return;
            if (checkedBtn.Name == "Easy")
                difficulty = dif.easy;
            else if (checkedBtn.Name == "Medium")
                difficulty = dif.medium;
            else if (checkedBtn.Name == "Hard")
                difficulty = dif.hard;
        }
    }
}
