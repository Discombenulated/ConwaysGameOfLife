namespace GameOfLife;

public class DeadCell : Cell
{
    public bool IsAlive(){
        return false;
    }

    public Cell Step(int numberOfLiveNeighbours)
    {
        if (numberOfLiveNeighbours == 3){
            return new AliveCell();
        }
        return this;
    }

    public override string ToString()
    {
        return "0";
    }
}