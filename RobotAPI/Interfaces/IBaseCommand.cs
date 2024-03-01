using System;
using RobotAPI.Models.Coordinates;
using RobotAPI.Convertors;

namespace RobotAPI.Interfaces;


public interface IBaseCommand
{

    bool ConsumeBattery(ref int battery);


    (bool hitWall, bool cleaning, bool batteryOk) Execute(MapItem[][] map, ref int battery, DirectionCoordinates actualPosition);
}

