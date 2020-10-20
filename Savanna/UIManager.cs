namespace Savanna
{
    using System;

    /// <summary>
    /// Manages console actions
    /// </summary>
    public class UIManager
    {
        /// <summary>
        /// Game grid drawing logic
        /// </summary>
        /// <param name="grid">Game char grid</param>
        public void Draw(char[,] grid)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
