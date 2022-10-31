using NUnit.Framework;

namespace GameOfLife.Test;

public class CellTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CellIsAlive()
    {
        Cell c = new Cell();
        Assert.IsTrue(c.IsAlive());
    }
}