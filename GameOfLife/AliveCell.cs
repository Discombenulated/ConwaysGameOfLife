namespace GameOfLife;

public class AliveCell : Cell
{
    public bool IsAlive(){
        return true;
    }

    public Cell Step(int numberOfLiveNeighbours)
    {
        if (numberOfLiveNeighbours == 2 || numberOfLiveNeighbours == 3){
            return this;
        }
        return new DeadCell();
    }
}