using System;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using RobotAPI.Models;
using RobotAPI.Models.Coordinates;

namespace RobotAPI.Dtos;

/// <summary>
/// Return object for Game object
/// </summary>
public class RobotOutputDto
{
    /// <summary>
    /// Visited coordinates
    /// </summary>
    public required BaseCoordinates[] Visited { get; set; }

    /// <summary>
    /// Cleaned coordinates
    /// </summary>
    public required BaseCoordinates[] Cleaned { get; set; }

    /// <summary>
    /// Final coordinates
    /// </summary>
    public required CoordinatesOutputDto Final { get; set; }

    /// <summary>
    /// Baterry state
    /// </summary>
    public required int Battery { get; set; }
}

