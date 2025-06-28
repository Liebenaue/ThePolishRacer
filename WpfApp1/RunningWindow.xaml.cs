using System;
using System.Collections.Generic;
using System.IO;
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
        private Vector currentDirection = new Vector(1, 0);
        private bool isPaused = false;
        private int fuel = 0;
        private Random rand = new Random();

        public RunningWindow()
        {
            InitializeComponent();
            Focusable = true;
            Keyboard.Focus(this);
            KeyDown += Page_KeyDown;
            Loaded += Page_Loaded;
            gameTimer.Interval = TimeSpan.FromMilliseconds(30);
            gameTimer.Tick += GameTick;
            StartGame();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                isPaused = !isPaused;
                return;
            }

            if (isPaused) return;

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
            try
            {
                string[] lines = File.ReadAllLines("data.txt");
                if (lines.Length > 9 && int.TryParse(lines[9], out int f))
                {
                    fuel = f;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd odczytu paliwa: " + ex.Message);
                fuel = 0;
            }

            if (fuel <= 0)
            {
                MessageBox.Show("Brak paliwa! Nie możesz zagrać.", "Błąd");
                NavigationService?.GoBack();
                return;
            }

            snake.Clear();
            snake.Add(new Point(5, 5));
            currentDirection = new Vector(1, 0);
            score = 0;
            SpawnFood();
            gameTimer.Start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            if (isPaused) return;

            Point currentHead = snake[0];
            Point newHead = new Point(currentHead.X + currentDirection.X, currentHead.Y + currentDirection.Y);

            if (newHead.X < 0 || newHead.Y < 0 || newHead.X >= cols || newHead.Y >= rows || snake.Contains(newHead))
            {
                EndGame();
                return;
            }

            bool ateFood = (newHead == food);
            if (!ateFood)
            {
                snake.RemoveAt(snake.Count - 1);
            }
            snake.Insert(0, newHead);
            if (ateFood)
            {
                score++;
                SpawnFood();
            }
            DrawGame();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            try
            {
                string[] lines = File.ReadAllLines("data.txt");
                if (lines.Length > 16 && int.TryParse(lines[16], out int currentMoney))
                {
                    int newMoney = currentMoney + score;
                    lines[16] = newMoney.ToString();
                }
                if (lines.Length > 9 && int.TryParse(lines[9], out int currentFuel))
                {
                    currentFuel = Math.Max(0, currentFuel - 1);
                    lines[9] = currentFuel.ToString();
                }
                File.WriteAllLines("data.txt", lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message);
            }

            MessageBox.Show($"Rozbiłeś się! Zgodnie z twoim wynikiem zarobiłeś: {score} złote.", "Koniec gry");
            NavigationService?.GoBack();
        }

        private void SpawnFood()
        {
            do
            {
                food = new Point(rand.Next(cols), rand.Next(rows));
            }
            while (snake.Contains(food));
        }

        private void DrawGame()
        {
            GameCanvas.Children.Clear();

            foreach (Point p in snake)
            {
                Rectangle segment = new Rectangle
                {
                    Width = gridSize,
                    Height = gridSize,
                    Fill = Brushes.Blue
                };
                Canvas.SetLeft(segment, p.X * gridSize);
                Canvas.SetTop(segment, p.Y * gridSize);
                GameCanvas.Children.Add(segment);
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

