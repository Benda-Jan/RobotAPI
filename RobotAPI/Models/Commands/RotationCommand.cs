using System;
using RobotAPI.Interfaces;
using RobotAPI.Models.Coordinates;
using RobotAPI.Convertors;

namespace RobotAPI.Models.Commands;

public class RotationCommand : BaseCommand, IBaseCommand
{
    private Direction[] internalDirectionList = { DirectionType.North, DirectionType.East, DirectionType.South, DirectionType.West };

    public override (bool hitWall, bool cleaning, bool batteryOk) Execute(MapItem[][] map, ref int battery, DirectionCoordinates actualPosition)
    {
        if (!ConsumeBattery(ref battery))
            return (false, false, false);

        if (actualPosition.Facing.Equals(DirectionType.Unknown))
            throw new BadHttpRequestException("Wrong direction");

        actualPosition.Facing = internalDirectionList[(Array.IndexOf(internalDirectionList, actualPosition.Facing) + PositionChange + 4) % 4];
        return (false, false, true);
    }
}

