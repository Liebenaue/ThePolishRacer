using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    public partial class RunningWindow : Page
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private List<Point> snake = new List<Point>();
        private Point food = new Point();
        private int gridSize = 20;
        private int rows = 20;
        private int cols = 30;
        private int score = 0;
        private Vector currentDirection = new Vector(1, 0); // Start: prawo

        public RunningWindow()
        {
            InitializeComponent();

            this.Focusable = true;
            this.Focus();
            this.KeyDown += Page_KeyDown;
            this.Loaded += Page_Loaded;

            gameTimer.Interval = TimeSpan.FromMilliseconds(200);
            gameTimer.Tick += GameTick;

            StartGame();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && currentDirection != new Vector(0, 1))
                currentDirection = new Vector(0, -1);
            else if (e.Key == Key.Down && currentDirection != new Vector(0, -1))
                currentDirection = new Vector(0, 1);
            else if (e.Key == Key.Left && currentDirection != new Vector(1, 0))
                currentDirection = new Vector(-1, 0);
            else if (e.Key == Key.Right && currentDirection != new Vector(-1, 0))
                currentDirection = new Vector(1, 0);
        }

        private void StartGame()
        {
            snake.Clear();
            snake.Add(new Point(5, 5));
            currentDirection = new Vector(1, 0);
            score = 0;
            SpawnFood();
            gameTimer.Start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            Point newHead = new Point(snake[0].X + currentDirection.X, snake[0].Y + currentDirection.Y);

            // Kolizja ze ścianą lub samym sobą
            if (newHead.X < 0 || newHead.Y < 0 || newHead.X >= cols || newHead.Y >= rows || snake.Contains(newHead))
            {
                gameTimer.Stop();

                // Wczytaj plik
                string[] lines = File.ReadAllLines("data.txt");

                if (lines.Length > 16)
                {
                    if (int.TryParse(lines[16], out int currentMoney))
                    {
                        int newMoney = currentMoney + score;
                        lines[16] = newMoney.ToString();
                        File.WriteAllLines("data.txt", lines);
                    }
                }

                MessageBox.Show($"Rozbiłeś się! Zgodnie z twoim wynikiem zarobiłeś: {score} złote", "Koniec gry");
                this.NavigationService.GoBack();
                return;
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                score++;
                SpawnFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            DrawGame();
        }

        private void SpawnFood()
        {
            Random rand = new Random();
            do
            {
                food = new Point(rand.Next(cols), rand.Next(rows));
            } while (snake.Contains(food));
        }

        private void DrawGame()
        {
            GameCanvas.Children.Clear();

            foreach (Point p in snake)
            {
                Rectangle rect = new Rectangle
                {
                    Width = gridSize,
                    Height = gridSize,
                    Fill = Brushes.Green
                };
                Canvas.SetLeft(rect, p.X * gridSize);
                Canvas.SetTop(rect, p.Y * gridSize);
                GameCanvas.Children.Add(rect);
            }

            Rectangle foodRect = new Rectangle
            {
                Width = gridSize,
                Height = gridSize,
                Fill = Brushes.Red
            };
            Canvas.SetLeft(foodRect, food.X * gridSize);
            Canvas.SetTop(foodRect, food.Y * gridSize);
            GameCanvas.Children.Add(foodRect);

            ScoreLabel.Content = $"Wynik: {score}";
        }
    }
}
