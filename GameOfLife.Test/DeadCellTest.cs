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
}