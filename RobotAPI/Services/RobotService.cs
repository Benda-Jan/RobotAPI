
using RobotAPI.Dtos;
using RobotAPI.Models.Commands;
using RobotAPI.Models.Coordinates;
using RobotAPI.Convertors;

namespace RobotAPI.Services;

public class RobotService
{
    private BaseCommand[][] backOfStrategy = new BaseCommand[5][]
        {
            new BaseCommand[3] {CommandFactory.Create("bckTR"), CommandFactory.Create("bckA"), CommandFactory.Create("bckTL") },
            new BaseCommand[3] {CommandFactory.Create("bckTR"), CommandFactory.Create("bckA"), CommandFactory.Create("bckTR") },
            new BaseCommand[3] {CommandFactory.Create("bckTR"), CommandFactory.Create("bckA"), CommandFactory.Create("bckTR") },
            new BaseCommand[4] {CommandFactory.Create("bckTR"), CommandFactory.Create("bckB"), CommandFactory.Create("bckTR"), CommandFactory.Create("bckA") },
            new BaseCommand[3] {CommandFactory.Create("bckTL"), CommandFactory.Create("bckTL"), CommandFactory.Create("bckA") }
        };

    public RobotOutputDto Simulate(RobotInputDto input)
	{
        // Initialization
        MapItem[][] map = input.Map.Select(x => x.Select(xx => MapItemConvertor.Convert(xx)).ToArray()).ToArray();
        var commands = input.Commands.Select(CommandFactory.Create).ToList();
        int battery = input.Battery;

        var actualPosition = DirectionCoordinates.From(input.Start);
        var visited = new HashSet<BaseCoordinates>(new CoordinatesEqualityComparer());
        var cleaned = new HashSet<BaseCoordinates>(new CoordinatesEqualityComparer());

        var actualStrategy = 0;

		// Executing loop
		while (commands.Any())
		{
            var command = commands.Take(1).Single();
            commands = commands.Skip(1).ToList();

            (var hitWall, var cleaning, var batteryOk) = command.Execute(map, ref battery, actualPosition);
            var resultPosition = new DirectionCoordinates() { Facing = actualPosition.Facing, X = actualPosition.X, Y = actualPosition.Y };

            visited.Add(resultPosition);
            if (cleaning)
                cleaned.Add(resultPosition);

            if (!batteryOk)
				break;

			if (!hitWall)
				continue;

            if (!commands.Any(x => x.CommandType == CommandType.BackOff))
                actualStrategy = 0;

            commands = backOfStrategy[actualStrategy % backOfStrategy.Length].Concat(commands.Where(x => x.CommandType == CommandType.User)).ToList();
            actualStrategy++;
		}

		return new RobotOutputDto() { Visited = visited.Reverse().ToArray(), Cleaned = cleaned.Reverse().ToArray(), Final = CoordinatesOutputDto.From(actualPosition), Battery = battery };
    }
}

