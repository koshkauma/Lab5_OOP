public static void DisplayRandomShip(Random rand, byte code, ref byte deck, ref byte[,] tmp_map)
{
    const
        byte VERTICAL_SHIP = 1;
    byte[,] tmp_ship = new byte[MATRIX_SIZE, MATRIX_SIZE];
    bool isReverse = false;
    while (deck > 0)
    {
        byte ORIENTATION = (byte)rand.Next(0, 2);
        do
        {
            tmp_ship = ClearShip(tmp_ship);
            isReverse = false;
            int x = rand.Next(0, MATRIX_SIZE), y = rand.Next(0, MATRIX_SIZE);
            short k = 0;
            for (int i = 0; i < code; i++)
            {
                if (ORIENTATION == VERTICAL_SHIP)
                {

                    if (y + k >= MATRIX_SIZE)
                    {
                        k = -1;
                        isReverse = true;
                    }
                    tmp_ship[x, y + k] = code;
                }
                else
                {
                    if (x + k >= MATRIX_SIZE)
                    {
                        k = -1;
                        isReverse = true;
                    }
                    tmp_ship[x + k, y] = code;
                }
                if (!isReverse)
                    k++;
                else
                    k--;
            }
        }
        while (!CheckCellPlacement(tmp_map, tmp_ship));
        for (byte i = 0; i < MATRIX_SIZE; i++)
            for (byte j = 0; j < MATRIX_SIZE; j++)
                if (tmp_ship[i, j] != EMPTY_FIELD)
                {
                    tmp_map[i, j] = tmp_ship[i, j];
                    tmp_ship[i, j] = EMPTY_FIELD;
                }
        deck--;
    }
}