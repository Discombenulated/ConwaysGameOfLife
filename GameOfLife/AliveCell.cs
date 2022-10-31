namespace GameOfLife;

public class AliveCell : Cell
{
    public bool IsAlive(){
        return true;
    }

    public Cell Step(int numberOfLiveNeighbours)
    {
        return new DeadCell();
    }
}