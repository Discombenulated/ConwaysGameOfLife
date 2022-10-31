namespace GameOfLife;

public class Grid
{
    private Cell[,] cells;

    public Grid(int[,] gridMap)
    {
        cells = new Cell[gridMap.Rank, gridMap.GetLength(0)];
        for (int x = 0; x < gridMap.Rank; x++){
            for (int y = 0; y < gridMap.GetLength(x); y++){
                cells[x,y] = new AliveCell();
            }
        }
    }

    public int Width { get; }
    public int Height { get; }

    public bool HasLiveCellAt(int x, int y)
    {
        return cells[x,y].IsAlive();
    }
}