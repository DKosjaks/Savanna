namespace Savanna
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Timers;

    /// <summary>
    /// Game and animal logic
    /// </summary>
    public class GameEngine
    {
        private const int _width = 40, _height = 20;
        private char[,] _grid;
        private UIManager _uIManager;
        private Timer _timer;
        private readonly List<Animal> _animals;

        /// <summary>
        /// Game and animal logic
        /// </summary>
        public GameEngine()
        {
            _uIManager = new UIManager();
            _animals = new List<Animal>();
            _grid = new char[_height, _width];
        }

        /// <summary>
        /// Inits game loop
        /// </summary>
        public void StartGame()
        {
            InitGrid();

            _timer = new Timer(1000);
            _timer.Elapsed += (sender, e) => OnTimedGameEvent();
            _timer.AutoReset = true;
            _timer.Enabled = true;

            var run = true;
            while (run)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        AddAnimal("Antelope", 'A', TypeEnum.Prey);
                        break;
                    case ConsoleKey.L:
                        AddAnimal("Lion", 'L', TypeEnum.Predator);
                        break;
                    case ConsoleKey.Spacebar:
                        _timer.Stop();
                        _timer.Dispose();
                        run = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Grid drawing which is being run on timer
        /// </summary>
        private void OnTimedGameEvent()
        {
            _uIManager.Draw(_grid);
            MoveAnimals();
        }

        /// <summary>
        /// Create new animal object and add it to list and grid
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="icon">Animal icon displayed on screen</param>
        /// <param name="type">Animal type</param>
        private void AddAnimal(string name, char icon, TypeEnum type)
        {
            var animal = new Animal
            {
                Name = name,
                Icon = icon,
                Health = 100,
                X = RandomNumberGenerator.GetInt32(1, _width),
                Y = RandomNumberGenerator.GetInt32(1, _height),
                Type = type
            };

            _animals.Add(animal);
            _grid[animal.Y, animal.X] = animal.Icon;
        }

        /// <summary>
        /// Moves animals randomly on grid
        /// </summary>
        private void MoveAnimals()
        {
            if (_animals.Count > 0)
            {
                foreach (var animal in _animals)
                {
                    _grid[animal.Y, animal.X] = ' ';
                    animal.X = RandomNumberGenerator.GetInt32(
                        animal.X - 1 == 0 ? 1 : animal.X - 1,
                        animal.X + 2 >= _width ? _width - 1 : animal.X + 2
                        );
                    animal.Y = RandomNumberGenerator.GetInt32(
                        animal.Y - 1 == 0 ? 1 : animal.Y - 1,
                        animal.Y + 2 >= _height ? _height - 1 : animal.Y + 2
                        );
                    _grid[animal.Y, animal.X] = animal.Icon;
                    animal.Health -= 0.5;
                }
            }
        }

        /// <summary>
        /// Adding initial grid values
        /// </summary>
        private void InitGrid()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (i > 0 && j > 0 && i < _grid.GetLength(0) - 1 && j < _grid.GetLength(1) - 1)
                    {
                        _grid[i, j] = ' ';
                    }
                    else
                    {
                        _grid[i, j] = '*';
                    }
                }
            }
        }
    }
}
