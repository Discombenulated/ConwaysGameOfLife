namespace GameOfLife;

public class Grid
{
    private Cell[,] cells;

    public Grid(int[,] gridMap)
    {
        if (gridMap.Rank != 2) throw new InvalidOperationException("Should be a 2 dimensional array");
        cells = new Cell[gridMap.GetLength(0), gridMap.GetLength(1)];
        for (int x = 0; x < gridMap.Length; x++){
            for (int y = 0; y < gridMap.GetLength(x); y++){
                int aliveOrDead = gridMap[x, y];
                if (aliveOrDead == 1){
                    cells[x,y] = new AliveCell();
                } else {
                    cells[x,y] = new DeadCell();
                }
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