using System;

public class BoatMovements
{
    public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        int rows = gameMatrix.GetLength(0);
        int cols = gameMatrix.GetLength(1);

        // 1. Bounds check
        if (fromRow < 0 || fromRow >= rows || fromColumn < 0 || fromColumn >= cols ||
            toRow < 0 || toRow >= rows || toColumn < 0 || toColumn >= cols)
        {
            return false;
        }

        // 2. Destination must be water
        if (!gameMatrix[toRow, toColumn])
        {
            return false;
        }

        // 3. Movement rules

        // Move UP
        if (toRow == fromRow - 1 && toColumn == fromColumn)
        {
            return gameMatrix[toRow, toColumn];
        }

        // Move DOWN
        if (toRow == fromRow + 1 && toColumn == fromColumn)
        {
            return gameMatrix[toRow, toColumn];
        }

        // Move LEFT
        if (toRow == fromRow && toColumn == fromColumn - 1)
        {
            return gameMatrix[toRow, toColumn];
        }

        // Move RIGHT (2 spaces)
        if (toRow == fromRow && toColumn == fromColumn + 2)
        {
            // Cannot cross land
            if (!gameMatrix[fromRow, fromColumn + 1])
                return false;

            return gameMatrix[toRow, toColumn];
        }

        // Any other movement is invalid
        return false;
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

        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false
    }
}