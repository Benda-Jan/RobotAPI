using System;
using RobotAPI.Interfaces;
using RobotAPI.Models.Coordinates;
using RobotAPI.Convertors;

namespace RobotAPI.Models.Commands;

public enum CommandType
{
	User,
	BackOff
}

public abstract class BaseCommand : IBaseCommand
{
	public required int BatteryConsumption { get; set; }
	public int PositionChange { get; set; }
	public CommandType CommandType { get; set; }

    public abstract (bool hitWall, bool cleaning, bool batteryOk) Execute(MapItem[][] map, ref int battery, DirectionCoordinates actualPosition);

	public bool ConsumeBattery(ref int battery)
	{
		if (battery - BatteryConsumption <= 0)
			return false;

		battery -= BatteryConsumption;
		return true;
	}
}

