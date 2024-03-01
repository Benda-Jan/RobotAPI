using System;

namespace RobotAPI.Models.Coordinates;

/// <summary>
/// Used to compare BaseCoordinates
/// </summary>
public class CoordinatesEqualityComparer : IEqualityComparer<BaseCoordinates>
{
    /// <summary>
    /// Check equality of BaseCoordinates
    /// </summary>
    public bool Equals(BaseCoordinates? obj1, BaseCoordinates? obj2)
    {
        return obj1?.X == obj2?.X && obj1?.Y == obj2?.Y;
    }

    /// <summary>
    /// Generates Hash Code
    /// </summary>
    public int GetHashCode(BaseCoordinates obj)
    {
        return obj.X.GetHashCode() + obj.Y.GetHashCode();
    }
}

