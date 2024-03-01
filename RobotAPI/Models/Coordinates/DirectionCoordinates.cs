using System;
using RobotAPI.Dtos;

namespace RobotAPI.Models.Coordinates;

/// <summary>
/// Coordinates with direction specification
/// </summary>
public class DirectionCoordinates : BaseCoordinates
{
    /// <summary>
    /// Facing direction
    /// </summary>
	public Direction Facing { get; set; }

    /// <summary>
    /// CoordinatesInputDto convertor
    /// </summary>
    public static DirectionCoordinates From(CoordinatesInputDto input)
        => new DirectionCoordinates() { X = input.X, Y = input.Y, Facing = input.Facing };
}

