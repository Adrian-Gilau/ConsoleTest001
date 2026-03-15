using System;

public class BoatMovements
{
    public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        int rows = gameMatrix.GetLength(0);
        int cols = gameMatrix.GetLength(1);

        if (toRow < 0 || toRow >= rows || toColumn < 0 || toColumn >= cols)
        {
            return false; // Out of bounds
        }

        if (!gameMatrix[toRow, toColumn])
        {
            return false; // Can't travel through land
        }

        if (fromRow == toRow)
        {
            int step = fromColumn < toColumn ? 1 : -1;
            for (int col = fromColumn; col != toColumn; col += step)
            {
                if (!gameMatrix[fromRow, col])
                {
                    return false;
                }
            }
        }
        else if (fromColumn == toColumn)
        {
            int step = fromRow < toRow ? 1 : -1;
            for (int row = fromRow; row != toRow; row += step)
            {
                if (!gameMatrix[row, fromColumn])
                {
                    return false;
                }
            }
        }
        else
        {
            return false; // Only horizontal or vertical moves allowed
        }

        return true;
    }

    public static void Main()
    {
        bool[,] gameMatrix =
        {
            {false, true,  true,  false, false, false},
            {true,  true,  true,  false, false, false},
            {true,  true,  true,  true,  true,  true},
            {false, true,  true,  false, true,  true},
            {false, true,  true,  true,  false, true},
            {false, false, false, false, false, false},
        };

        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true, Valid move
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false, Can't travel through land
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false, Out of bounds
    }
}