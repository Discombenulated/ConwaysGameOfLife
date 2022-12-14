using System;
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

    [Test]
    public void OneByOneGridCellAtOriginIsDeadAfterStep()
    {
        Grid g = new Grid(new int[,] {{1}});
        g = g.Step();
        Assert.IsFalse(g.HasLiveCellAt(0,0));
    }

    [Test]
    public void TwoByTwoGridCellAtOriginAliveAfterOneStep()
    {
        Grid g = new Grid(new int[,] {{1,1}, {1,0}});
        g = g.Step();
        Assert.IsTrue(g.HasLiveCellAt(0,0));
        Assert.IsTrue(g.HasLiveCellAt(0,1));
        Assert.IsTrue(g.HasLiveCellAt(1,1));
        Assert.IsTrue(g.HasLiveCellAt(1,0));
    }

    [Test]
    public void TwoByTwoGridsAreEqual()
    {
        Grid g = new Grid(new int[,] {{1,1}, {1,0}});
        Grid g2 = new Grid(new int[,]{{1,1}, {1,0}});
        Assert.AreEqual(g, g2);
    }
    
    [Test]
    public void TwoByTwoGridsAreNotEqual()
    {
        Grid g = new Grid(new int[,] {{1,1}, {1,0}});
        Grid g2 = new Grid(new int[,]{{1,1}, {1,1}});
        Assert.AreNotEqual(g, g2);
    }

    [Test]
    public void TwoByTwoGridStringRepresentation()
    {
        Grid g = new Grid(new int[,] {{1,1}, {1,0}});
        var expected = "1 1" + Environment.NewLine + "1 0";
        Assert.AreEqual(expected, g.ToString());
    }

    [Test]
    public void TwoByThreeGridStringRepresentation()
    {
        Grid g = new Grid(new int[,] {{1,1,1}, {1,0,1}});
        var expected = "1 1 1" + Environment.NewLine + "1 0 1";
        Assert.AreEqual(expected, g.ToString());
    }

    [Test]
    public void ThreeByThreeGridCellCorrectAfterTwoSteps()
    {
        Grid g = new Grid(new int[,] {{1,1,0}, {1,0,0}, {0,0,0}});
        g = g.Step();
        Grid g2 = new Grid(new int[,] {{1,1,0}, {1,1,0}, {0,0,0}});
        Assert.AreEqual(g2, g);
        g = g.Step();
        Grid g3 = new Grid(new int[,] {{1,1,0}, {1,1,0}, {0,0,0}});
        Assert.AreEqual(g3, g);
    }

    [Test]
    public void ThreeByThreeGridCellCorrectAfterTwoSteps_2()
    {
        Grid g = new Grid(new int[,] {{1,1,1}, {1,0,0}, {1,0,0}});
        g = g.Step();
        Grid g2 = new Grid(new int[,] {{1,1,0}, {1,0,0}, {0,0,0}});
        Assert.AreEqual(g2, g);
        g = g.Step();
        Grid g3 = new Grid(new int[,] {{1,1,0}, {1,1,0}, {0,0,0}});
        Assert.AreEqual(g3, g);
    }

    [Test]
    public void ThreeByThreeGridCellCorrectAfterTwoSteps_3()
    {
        Grid g = new Grid(new int[,] {{1,0,1}, {0,0,0}, {1,0,0}});
        g = g.Step();
        Grid g2 = new Grid(new int[,] {{0,0,0}, {0,1,0}, {0,0,0}});
        Assert.AreEqual(g2, g);
        g = g.Step();
        Grid g3 = new Grid(new int[,] {{0,0,0}, {0,0,0}, {0,0,0}});
        Assert.AreEqual(g3, g);
    }

    [Test]
    public void Oscillator_Beacon()
    {
        Grid g = new Grid(new int[,] {{1,1,0,0}, {1,1,0,0}, {0,0,1,1}, {0,0,1,1}});
        g = g.Step();
        Grid g2 = new Grid(new int[,] {{1,1,0,0}, {1,0,0,0}, {0,0,0,1}, {0,0,1,1}});
        Assert.AreEqual(g2, g);
        g = g.Step();
        Grid g3 = new Grid(new int[,] {{1,1,0,0}, {1,1,0,0}, {0,0,1,1}, {0,0,1,1}});
        Assert.AreEqual(g3, g);
    }

    [Test]
    public void Still_Tub(){
        Grid g = new Grid(new int[,] {{0,1,0}, {1,0,1}, {0,1,0}});
        g = g.Step();
        Grid g2 = new Grid(new int[,] {{0,1,0}, {1,0,1}, {0,1,0}});
        Assert.AreEqual(g2, g);
    }
}