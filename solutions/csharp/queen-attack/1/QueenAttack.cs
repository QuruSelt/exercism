public class Queen
{
    public Queen(int row, int column)
    {
        if (row < 0 || column < 0 || row > 7 || column > 7) throw new ArgumentOutOfRangeException();
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        for (int i = 0; i < 8; i++) {
            if (white.Row + i == black.Row && white.Column + i == black.Column) return true;
            if (white.Row - i == black.Row && white.Column + i == black.Column) return true;
            if (white.Row + i == black.Row && white.Column - i == black.Column) return true;
            if (white.Row - i == black.Row && white.Column - i == black.Column) return true;
        }
        return (white.Row == black.Row || white.Column == black.Column);
    }

    public static Queen Create(int row, int column) => new Queen(row, column);
}