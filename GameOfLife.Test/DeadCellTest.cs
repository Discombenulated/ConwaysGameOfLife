using NUnit.Framework;

namespace GameOfLife.Test;

public class DeadCellTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CellIsDead()
    {
        Cell c = new DeadCell();
        Assert.IsFalse(c.IsAlive());
    }

    [Test]
    public void CellWillBeAliveInNextIterationIfThreeLiveNeighbours(){
        DeadCell ac = new DeadCell();
        Assert.IsTrue(ac.Step(3).IsAlive());
    }

    [Test]
    public void CellWillBeADeadInNextIterationIfNotThreeLiveNeighbours(){
        DeadCell ac = new DeadCell();
        Assert.IsFalse(ac.Step(0).IsAlive());
        Assert.IsFalse(ac.Step(2).IsAlive());
        Assert.IsFalse(ac.Step(4).IsAlive());
        Assert.IsFalse(ac.Step(99).IsAlive());
    }
}