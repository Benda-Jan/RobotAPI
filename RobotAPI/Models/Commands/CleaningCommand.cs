using System;
using RobotAPI.Interfaces;
using RobotAPI.Models.Coordinates;
using RobotAPI.Convertors;

namespace RobotAPI.Models.Commands;

public class CleaningCommand : BaseCommand, IBaseCommand
{
    public override (bool hitWall, bool cleaning, bool batteryOk) Execute(MapItem[][] map, ref int battery, DirectionCoordinates actualPosition)
    {
        var baterryOk = ConsumeBattery(ref battery);
        return (false, baterryOk, baterryOk);
    }
}
