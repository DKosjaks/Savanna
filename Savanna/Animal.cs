namespace Savanna
{
    /// <summary>
    /// Represents animal object
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Animal name
        /// </summary>
        public string Name { get; set; }

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
        /// Animal type
        /// </summary>
        public TypeEnum Type { get; set; }
    }
}
