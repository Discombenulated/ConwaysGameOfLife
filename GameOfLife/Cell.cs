namespace GameOfLife;

public interface Cell
{
    public bool IsAlive();

    public Cell Step(int numberOfLiveNeighbours);
}