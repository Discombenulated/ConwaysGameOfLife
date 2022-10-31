namespace GameOfLife;

public class Grid
{
    private Cell[,] cells;

    public Grid(int[,] gridMap)
    {
        if (gridMap.Rank != 2) throw new InvalidOperationException("Should be a 2 dimensional array");
        cells = new Cell[gridMap.GetLength(0), gridMap.GetLength(1)];
        for (int x = 0; x < gridMap.GetLength(0); x++){
            for (int y = 0; y < gridMap.GetLength(1); y++){
                int aliveOrDead = gridMap[x, y];
                if (aliveOrDead == 1){
                    cells[x,y] = new AliveCell();
                } else {
                    cells[x,y] = new DeadCell();
                }
            }
        }
    }

    private Grid(Cell[,] cells){
        this.cells = new Cell[cells.GetLength(0), cells.GetLength(1)];
        for (int x = 0; x < cells.GetLength(0); x++){
            for (int y = 0; y < cells.GetLength(1); y++){
                this.cells[x,y] = cells[x,y];
            }
        }
    }

    public int Width { get; }
    public int Height { get; }

    public bool HasLiveCellAt(int x, int y)
    {
        return cells[x,y].IsAlive();
    }

    private void SetCellAt(int x, int y, Cell cell){
        cells[x,y] = cell;
    }

    public Grid Step()
    {
        Grid g = new Grid(cells);
        g.SetCellAt(0,0, new DeadCell());
        return g;
    }
}