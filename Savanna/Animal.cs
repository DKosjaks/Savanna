namespace Savanna
{
    using System.Security.Cryptography;

    /// <summary>
    /// Represents animal object
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// Animal icon displayed on screen
        /// </summary>
        public char Icon { get; set; }

        /// <summary>
        /// Animal total health value
        /// </summary>
        public double Health { get; set; }

        /// <summary>
        /// Grid x position
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Grid y position
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Moves animal randomly on grid
        /// </summary>
        /// <param name="width">Max game field width</param>
        /// <param name="height">Max game field height</param>
        public void MoveRandomly(int width, int height)
        {
            X = RandomNumberGenerator.GetInt32(
                X - 1 == 0 ? 1 : X - 1,
                X + 2 >= width ? width - 1 : X + 2
                );
            Y = RandomNumberGenerator.GetInt32(
                Y - 1 == 0 ? 1 : Y - 1,
                Y + 2 >= height ? height - 1 : Y + 2
                );

            Health -= 0.5;
        }
    }
}
