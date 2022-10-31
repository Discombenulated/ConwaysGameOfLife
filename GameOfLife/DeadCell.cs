namespace GameOfLife;

public class DeadCell : Cell
{
    public bool IsAlive(){
        return false;
    }
}