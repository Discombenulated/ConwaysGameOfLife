using NUnit.Framework;

namespace GameOfLife.Test;

public class AliveCellTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CellIsAlive()
    {
        Cell c = new AliveCell();
        Assert.IsTrue(c.IsAlive());
    }

    [Test]
    public void CellWillBeDeadInNextIterationIfFewerThanTwoLiveNeighbours(){
        Cell ac = new AliveCell();
        Assert.IsFalse(ac.Step(0).IsAlive());
        Assert.IsFalse(ac.Step(1).IsAlive());
    }

    [Test]
    public void CellWillBeDeadInNextIterationIfMoreThanThreeLiveNeighbours(){
        Cell ac = new AliveCell();
        Assert.IsFalse(ac.Step(4).IsAlive());
        Assert.IsFalse(ac.Step(100).IsAlive());
    }

        [Test]
    public void CellWillBeAliveInNextIterationIfTwoOrThreeLiveNeighbours(){
        Cell ac = new AliveCell();
        Assert.IsTrue(ac.Step(2).IsAlive());
        Assert.IsTrue(ac.Step(3).IsAlive());
    }
}