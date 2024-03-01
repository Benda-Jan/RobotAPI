using System;

namespace RobotAPI.Convertors;

public enum MapItem
{
	Cleanable,
	NonCleanable,
	Wall,

}

public class MapItemConvertor
{
	public static MapItem Convert(string input)
		=> input switch
		{
			"S" => MapItem.Cleanable,
			"C" => MapItem.NonCleanable,
			_ => MapItem.Wall
		};
}

