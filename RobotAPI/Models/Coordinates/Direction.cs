using System;

namespace RobotAPI.Models.Coordinates;

public enum DirectionType
{
    North,
    South,
    East,
    West,
    Unknown
}

public readonly struct Direction
{
    private readonly DirectionType _direction;

    public Direction(string direction)
    {
        _direction = ToEnum(direction);
    }

    public Direction(DirectionType direction)
    {
        _direction = direction;
    }

    public override string ToString()
        => _direction switch
        {
            DirectionType.North => "N",
            DirectionType.South => "S",
            DirectionType.East => "E",
            DirectionType.West => "W",
            _ => ""
        };

    public static DirectionType ToEnum(string input)
        => input.ToUpper() switch
        {
            "N" => DirectionType.North,
            "S" => DirectionType.South,
            "E" => DirectionType.East,
            "W" => DirectionType.West,
            _ => DirectionType.Unknown
        };

    public bool Equals (DirectionType obj)
    {
        return _direction == obj;
    }

    public override bool Equals(object? obj)
    {
        return _direction.Equals((obj as Direction?)?._direction);
    }

    public override int GetHashCode()
    {
        return _direction.GetHashCode();
    }

    public static implicit operator string(Direction input) => input.ToString();

    public static implicit operator Direction(string input) => new Direction(input);

    public static implicit operator Direction(DirectionType input) => new Direction(input);
}

