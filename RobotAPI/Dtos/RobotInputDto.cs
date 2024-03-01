using System;
using RobotAPI.Models.Coordinates;

namespace RobotAPI.Dtos;

/// <summary>
/// Create object for Game object
/// </summary>
public class RobotInputDto
{
    /// <summary>
    /// Map of a room
    /// </summary>
    public required string[][] Map { get; set; }

    /// <summary>
    /// Starting position
    /// </summary>
    public required CoordinatesInputDto Start { get; set; }

    /// <summary>
    /// Command sequence
    /// </summary>
	public required string[] Commands { get; set; }

    /// <summary>
    /// Initial battery
    /// </summary>
    public required int Battery { get; set; }

    /// <summary>
    /// Validate inputs from HtppRequest
    /// </summary>
    public void Validate()
    {
        if (Start is null
            || Map is null
            || Start.X < 0
            || Start.X < 0
            || Map.Length <= 0
            || Map[0].Length <= 0
            || Start.X > Map.Length
            || Start.Y > Map[0].Length
            || Map[Start.X][Start.X] != "S"
            )
            throw new BadHttpRequestException("Robot starts on position of wall or out of coordinates");
    }
}


