using System;
using RobotAPI.Convertors;
using RobotAPI.Models.Commands;
using RobotAPI.Models.Coordinates;

namespace RobotAPI.Test;

public class CommandsTest
{
	[Fact]
	public void ConsumeBattery_MovementCommand(){
		int batteryConsumption = 5;
		var sut = new MovementCommand { BatteryConsumption = batteryConsumption };
		int fullBattery = 100;
        int changedBattery = fullBattery;

		sut.ConsumeBattery(ref changedBattery);

		Assert.Equal(changedBattery, fullBattery - batteryConsumption);
	}

    [Fact]
    public void ConsumeBattery_RotationCommand()
    {
        int batteryConsumption = 5;
        var sut = new RotationCommand { BatteryConsumption = batteryConsumption };
        int fullBattery = 100;
        int changedBattery = fullBattery;

        sut.ConsumeBattery(ref changedBattery);

        Assert.Equal(changedBattery, fullBattery - batteryConsumption);
    }

    [Fact]
    public void ConsumeBattery_CleaningCommand()
    {
        int batteryConsumption = 0;
        var sut = new CleaningCommand { BatteryConsumption = batteryConsumption };
        int fullBattery = 100;
        int changedBattery = fullBattery;

        sut.ConsumeBattery(ref changedBattery);

        Assert.Equal(changedBattery, fullBattery - batteryConsumption);
    }

    [Fact]
    public void RotationCommand_RotateCorrectly()
    {
        MapItem[][] map = {
            new MapItem[3] {MapItem.Cleanable, MapItem.Cleanable, MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        int battery = 1000;

        var sut = new RotationCommand() { BatteryConsumption = 1, CommandType = CommandType.User, PositionChange = 1 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.True(batteryOk);
        Assert.False(hitWall);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(DirectionType.East, actualPosition.Facing);
    }

    [Fact]
    public void RotationCommand_BatteryNok()
    {
        MapItem[][] map = {
            new MapItem[3] {MapItem.Cleanable, MapItem.Cleanable, MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        int battery = 5;

        var sut = new RotationCommand() { BatteryConsumption = 10, CommandType = CommandType.User, PositionChange = 1 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.False(hitWall);
        Assert.False(batteryOk);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }

    [Fact]
    public void CleaningCommand_CleanCorrectly()
    {
        MapItem[][] map = {
            new MapItem[3] {MapItem.Cleanable, MapItem.Cleanable, MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.East };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.East };
        int battery = 1000;

        var sut = new CleaningCommand() { BatteryConsumption = 1, CommandType = CommandType.User, PositionChange = 0 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.True(cleaning);
        Assert.True(batteryOk);
        Assert.False(hitWall);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }

    [Fact]
    public void CleaningCommand_BatteryNok()
    {
        MapItem[][] map = {
            new MapItem[3] {MapItem.Cleanable, MapItem.Cleanable, MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.East };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.East };
        int battery = 5;

        var sut = new CleaningCommand() { BatteryConsumption = 10, CommandType = CommandType.User, PositionChange = 0 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.False(batteryOk);
        Assert.False(hitWall);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }

    [Fact]
    public void MovementCommand_MoveCorrectlyX()
    {
        MapItem[][] map = {
            new MapItem[3] {MapItem.Cleanable, MapItem.Cleanable, MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.East };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.East };
        int battery = 1000;

        var sut = new MovementCommand() { BatteryConsumption = 1, CommandType = CommandType.User, PositionChange = 1 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.True(batteryOk);
        Assert.False(hitWall);
        Assert.Equal(referencePosition.X + 1, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }

    [Fact]
    public void MovementCommand_HitWallX()
    {
        MapItem[][] map = {
            new MapItem[3] {MapItem.Cleanable, MapItem.Cleanable, MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 1, Y = 0, Facing = DirectionType.East };
        var referencePosition = new DirectionCoordinates() { X = 1, Y = 0, Facing = DirectionType.East };
        int battery = 1000;

        var sut = new MovementCommand() { BatteryConsumption = 1, CommandType = CommandType.User, PositionChange = 1 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.True(batteryOk);
        Assert.True(hitWall);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }

    [Fact]
    public void MovementCommand_MoveCorrectlyY()
    {
        MapItem[][] map = {
            new MapItem[1] {MapItem.Cleanable },
            new MapItem[1] {MapItem.Cleanable },
            new MapItem[1] {MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        int battery = 1000;

        var sut = new MovementCommand() { BatteryConsumption = 1, CommandType = CommandType.User, PositionChange = -1 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.True(batteryOk);
        Assert.False(hitWall);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y + 1, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }

    [Fact]
    public void MovementCommand_HitWallY()
    {
        MapItem[][] map = {
            new MapItem[1] {MapItem.Cleanable },
            new MapItem[1] {MapItem.Cleanable },
            new MapItem[1] {MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 1, Facing = DirectionType.North };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 1, Facing = DirectionType.North };
        int battery = 1000;

        var sut = new MovementCommand() { BatteryConsumption = 1, CommandType = CommandType.User, PositionChange = -1 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.True(batteryOk);
        Assert.True(hitWall);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }

    [Fact]
    public void MovementCommand_BatteryNok()
    {
        MapItem[][] map = {
            new MapItem[3] {MapItem.Cleanable, MapItem.Cleanable, MapItem.Wall }
        };
        var actualPosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        var referencePosition = new DirectionCoordinates() { X = 0, Y = 0, Facing = DirectionType.North };
        int battery = 5;

        var sut = new MovementCommand() { BatteryConsumption = 10, CommandType = CommandType.User, PositionChange = 1 };
        (var hitWall, var cleaning, var batteryOk) = sut.Execute(map, ref battery, actualPosition);

        Assert.False(cleaning);
        Assert.False(batteryOk);
        Assert.False(hitWall);
        Assert.Equal(referencePosition.X, actualPosition.X);
        Assert.Equal(referencePosition.Y, actualPosition.Y);
        Assert.Equal(referencePosition.Facing, actualPosition.Facing);
    }
}

