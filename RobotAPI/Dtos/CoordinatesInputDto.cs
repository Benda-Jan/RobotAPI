using System;
using RobotAPI.Models.Coordinates;

namespace RobotAPI.Dtos
{
    public class CoordinatesInputDto
    {
        /// <summary>
        /// Position in X axis
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Position in Y axis
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Facing direction
        /// </summary>
        public string Facing { get; set; } = String.Empty;

        public static CoordinatesInputDto From(DirectionCoordinates input)
            => new CoordinatesInputDto() { X = input.X, Y = input.Y, Facing = input.Facing};
    }
}

