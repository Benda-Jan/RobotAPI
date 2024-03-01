using System;
using RobotAPI.Interfaces;

namespace RobotAPI.Models.Commands;


public class CommandFactory
{

	public static BaseCommand Create(string name)
		=> name switch
		{
            "A" => new MovementCommand() { BatteryConsumption = 2, PositionChange = 1, CommandType = CommandType.User },
            "B" => new MovementCommand() { BatteryConsumption = 3, PositionChange = -1, CommandType = CommandType.User },
            "TL" => new RotationCommand() { BatteryConsumption = 1, PositionChange = -1, CommandType = CommandType.User },
            "TR" => new RotationCommand() { BatteryConsumption = 1, PositionChange = 1, CommandType = CommandType.User },
            "bckA" => new MovementCommand() { BatteryConsumption = 2, PositionChange = 1, CommandType = CommandType.BackOff },
            "bckB" => new MovementCommand() { BatteryConsumption = 3, PositionChange = -1, CommandType = CommandType.BackOff },
            "bckTL" => new RotationCommand() { BatteryConsumption = 1, PositionChange = -1, CommandType = CommandType.BackOff },
            "bckTR" => new RotationCommand() { BatteryConsumption = 1, PositionChange = 1, CommandType = CommandType.BackOff },
            "C" => new CleaningCommand() { BatteryConsumption = 5 },
            _ => throw new BadHttpRequestException("Wrong Command")
		};
}

