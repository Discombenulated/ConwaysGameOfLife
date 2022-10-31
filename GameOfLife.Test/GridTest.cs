using NUnit.Framework;

namespace GameOfLife.Test;

public class GridTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void OneByOneGridCellAtOriginIsAlive()
    {
        Grid g = new Grid(1,1);
        Assert.IsTrue(g.HasLiveCellAt(0,0));
    }
}