using System;
using RobotAPI.Interfaces;
using RobotAPI.Models.Coordinates;
using RobotAPI.Convertors;

namespace RobotAPI.Models.Commands;

public class MovementCommand : BaseCommand, IBaseCommand
{

    public override (bool hitWall, bool cleaning, bool batteryOk) Execute(MapItem[][] map, ref int battery, DirectionCoordinates actualPosition)
    {
        if (!ConsumeBattery(ref battery))
            return (false, false, false);
        var hitWall = false;

        if (actualPosition.Facing.Equals(DirectionType.West))
        {
            int desiredPosition = actualPosition.X - PositionChange;
            if (desiredPosition < map[0].Length && desiredPosition >= 0 && map[actualPosition.Y][desiredPosition] == MapItem.Cleanable)
                actualPosition.X = desiredPosition;
            else
                hitWall = true;
        }
        else if (actualPosition.Facing.Equals(DirectionType.East))
        {
            int desiredPosition = actualPosition.X + PositionChange;
            if (desiredPosition < map[0].Length && desiredPosition >= 0 && map[actualPosition.Y][desiredPosition] == MapItem.Cleanable)
                actualPosition.X = desiredPosition;
            else
                hitWall = true;
        }
        else if (actualPosition.Facing.Equals(DirectionType.North))
        {
            int desiredPosition = actualPosition.Y - PositionChange;
            if (desiredPosition < map.Length && desiredPosition >= 0 && map[desiredPosition][actualPosition.X] == MapItem.Cleanable)
                actualPosition.Y = desiredPosition;
            else
                hitWall = true;
        }
        else if (actualPosition.Facing.Equals(DirectionType.South))
        {
            int desiredPosition = actualPosition.Y + PositionChange;
            if (desiredPosition < map.Length && desiredPosition >= 0 && map[desiredPosition][actualPosition.X] == MapItem.Cleanable)
                actualPosition.Y = desiredPosition;
            else
                hitWall = true;
        }
        return (hitWall, false, true);
    }
}

