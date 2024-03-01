using System;
using RobotAPI.Models.Coordinates;

namespace RobotAPI.Test;

public class CoordinatesTest
{

    [Fact]
    public void CoordinatesComparer_Equals_Correct()
    {
        var sut1 = new BaseCoordinates()
        {
            X = 10,
            Y = 5
        };

        var sut2 = new BaseCoordinates()
        {
            X = 10,
            Y = 5
        };
        var comparer = new CoordinatesEqualityComparer();

        Assert.True(comparer.Equals(sut1, sut2));
    }

    [Fact]
    public void DirectionToEnum_Correct()
    {
        var dirN = new Direction("N");
        var dirS = new Direction("S");
        var dirE = new Direction("E");
        var dirW = new Direction("W");

        Assert.True(dirN.Equals(DirectionType.North));
        Assert.True(dirS.Equals(DirectionType.South));
        Assert.True(dirE.Equals(DirectionType.East));
        Assert.True(dirW.Equals(DirectionType.West));
    }

    [Fact]
    public void DirectionToString_Correct()
    {
        var dirN = new Direction(DirectionType.North);
        var dirS = new Direction(DirectionType.South);
        var dirE = new Direction(DirectionType.East);
        var dirW = new Direction(DirectionType.West);

        Assert.Equal(dirN.ToString(), "N");
        Assert.Equal(dirS.ToString(), "S");
        Assert.Equal(dirE.ToString(), "E");
        Assert.Equal(dirW.ToString(), "W");
    }

}

