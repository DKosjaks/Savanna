namespace Savanna
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Timers;

    /// <summary>
    /// Game field and animal logic
    /// </summary>
    public class GameEngine
    {
        private const int _width = 40, _height = 20;
        private char[,] _grid;
        private UIManager _uIManager;
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
            Timer _timer = new Timer(1000);
            _timer.Elapsed += (sender, e) => OnTimedGameEvent();
            _timer.AutoReset = true;
            _timer.Enabled = true;

            var run = true;
            while (run)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        AddAntelope('A');
                        break;
                    case ConsoleKey.L:
                        AddLion('L');
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
            Die();
        }

        /// <summary>
        /// Create new animal object and add it to list and grid
        /// </summary>
        /// <param name="icon">Animal icon displayed on screen</param>
        private void AddLion(char icon)
        {
            var animal = new Lion
            {
                Icon = icon,
                Health = 10,
                X = RandomNumberGenerator.GetInt32(1, _width - 1),
                Y = RandomNumberGenerator.GetInt32(1, _height - 1)
            };

            _animals.Add(animal);
            _grid[animal.Y, animal.X] = animal.Icon;
        }

        /// <summary>
        /// Create new animal object and add it to list and grid
        /// </summary>
        /// <param name="icon">Animal icon displayed on screen</param>
        private void AddAntelope(char icon)
        {
            var animal = new Antelope
            {
                Icon = icon,
                Health = 10,
                X = RandomNumberGenerator.GetInt32(1, _width - 1),
                Y = RandomNumberGenerator.GetInt32(1, _height - 1)
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
                    animal.MoveRandomly(_width, _height);
                    _grid[animal.Y, animal.X] = animal.Health > 0 ? animal.Icon : ' ';
                }
            }
        }

        /// <summary>
        /// Remove from list when health drops to 0
        /// </summary>
        private void Die()
        {
            _animals.RemoveAll(x => x.Health <= 0);
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
