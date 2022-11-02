using System.Text;

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
        this.cells = cells;
    }

    private int Width { get{
        return cells.GetLength(1);
    } }
    private int Height { get{
        return cells.GetLength(0);
    } }

    public bool HasLiveCellAt(int x, int y)
    {
        return cells[x,y].IsAlive();
    }

    private void SetCellAt(int x, int y, Cell cell){
        cells[x,y] = cell;
    }

    public Grid Step()
    {
        Cell[,] newCells = new Cell[cells.GetLength(0), cells.GetLength(1)]; 
        for (int x = 0; x < cells.GetLength(0); x++){
            for (int y = 0; y < cells.GetLength(1); y++){
                int numberOfLiveNeighbours = countLiveNeighbours(x,y);
                newCells[x,y] = cells[x,y].Step(numberOfLiveNeighbours);
            }
        }
        return new Grid(newCells);
    }

    private int countLiveNeighbours(int x, int y)
    {
        int numberOfLiveNeighbours = 0;
        for (int currentX = x-1; currentX < x+2; currentX++){
            if (currentX >= 0 && currentX < cells.GetLength(0) ){
                for (int currentY = y-1; currentY < y+2; currentY++){
                    if (currentX == x && currentY == y) continue;
                    if (currentY >= 0 && currentY < cells.GetLength(1) ){
                        if (cells[currentX, currentY].IsAlive()) {
                            numberOfLiveNeighbours++;
                        }
                    }
                }
            }
        }   
        return numberOfLiveNeighbours;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Grid) return false;
        return Equals((Grid)obj);
    }

    public bool Equals(Grid other){
        if (cells.GetLength(0) != other.cells.GetLength(0)) return false;
        if (cells.GetLength(1) != other.cells.GetLength(1)) return false;
        for (int x = 0; x < cells.GetLength(0); x++){
            for (int y = 0; y < cells.GetLength(1); y++){
                if (cells[x,y].IsAlive() != other.cells[x,y].IsAlive()){
                    return false;
                }
            }
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < Height; y++){
            if (y > 0) {
                sb.Append(Environment.NewLine);
            }
            for (int x = 0; x < Width; x++){
                if (x > 0) {
                    sb.Append(" ");
                }
                sb.Append(cells[y,x]);
            }
        }
        return sb.ToString();
    }
}