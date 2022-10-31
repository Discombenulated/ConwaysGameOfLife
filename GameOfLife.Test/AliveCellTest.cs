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
}