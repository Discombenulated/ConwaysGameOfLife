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
        Grid g = new Grid(new int[,] {{1}});
        Assert.IsTrue(g.HasLiveCellAt(0,0));
    }

    [Test]
    public void OneByOneGridCellAtOriginIsDead()
    {
        Grid g = new Grid(new int[,] {{0}});
        Assert.IsFalse(g.HasLiveCellAt(0,0));
    }

    [Test]
    public void OneByTwoGridCellAtOriginIsAlive()
    {
        Grid g = new Grid(new int[,] {{1}, {0}});
        Assert.IsTrue(g.HasLiveCellAt(0,0));
    }

    [Test]
    public void OneByTwoGridCellAtOriginIsDead()
    {
        Grid g = new Grid(new int[,] {{0}, {0}});
        Assert.IsFalse(g.HasLiveCellAt(0,0));
    }

    [Test]
    public void TwoByOneGridCellAtOriginIsAlive()
    {
        Grid g = new Grid(new int[,] {{1,0}});
        Assert.IsTrue(g.HasLiveCellAt(0,0));
    }

    [Test]
    public void TwoByOneGridCellAtOriginIsDead()
    {
        Grid g = new Grid(new int[,] {{0,0}});
        Assert.IsFalse(g.HasLiveCellAt(0,0));
    }

    [Test]
    public void TwoByTwoGridCellAtOriginIsAlive()
    {
        Grid g = new Grid(new int[,] {{1,0}, {0,0}});
        Assert.IsTrue(g.HasLiveCellAt(0,0));
        Assert.IsFalse(g.HasLiveCellAt(0,1));
        Assert.IsFalse(g.HasLiveCellAt(1,1));
        Assert.IsFalse(g.HasLiveCellAt(1,0));
    }

    [Test]
    public void TwoByTwoGridCellAtOriginIsDead()
    {
        Grid g = new Grid(new int[,] {{0,1}, {1,1}});
        Assert.IsFalse(g.HasLiveCellAt(0,0));
        Assert.IsTrue(g.HasLiveCellAt(0,1));
        Assert.IsTrue(g.HasLiveCellAt(1,1));
        Assert.IsTrue(g.HasLiveCellAt(1,0));
    }
}