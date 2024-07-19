namespace WebApplication2.Models
{
    public class FieldManager
    {
        private static Random rnd = new Random();
        public static string[,] CreateFieldFull(int width, int height, int mines_count, int x, int y)
        {
            var field = new string[height, width];
            field = FillField(field, PlaySymbol.emptyСellFull);
            field = FillBombField(field, mines_count, x, y, PlaySymbol.emptyСellFull, PlaySymbol.bombСell);
            field = FillNearBombField(field, PlaySymbol.bombСell);
            return field;
        }




        public static string[,] CreateFieldUser(int width, int height)
        {
            var field = new string[height, width];
            field = FillField(field, PlaySymbol.emptyСellUser);
            return field;
        }




        private static String[,] FillField(String[,] field, String emptyСell)
        {
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.Length / field.GetLength(0); j++)
                    field[i, j] = emptyСell;
            return field;
        }

        private static String[,] FillBombField(String[,] field, int mines_count, int x, int y, string emptyСell, string bombCell)
        {
            int count = 0;
            while (count < mines_count)
            {
                int i = rnd.Next(0, field.GetLength(0));
                int j = rnd.Next(0, field.Length / field.GetLength(0));

                if (i == y && j == x)
                    continue;

                if (field[i, j] == emptyСell)
                {
                    field[i, j] = bombCell;
                    count++;
                }
            }
            return field;
        }

        private static String[,] FillNearBombField(String[,] field, string bombCell)
        {
            int height = field.GetLength(0);
            int width = field.Length / field.GetLength(0);



            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int countBomb = 0;
                    if (field[i, j] == bombCell)
                        continue;
                    for (int i1 = -1; i1 <= 1; i1++)
                    {
                        for (int j1 = -1; j1 <= 1; j1++)
                        {
                            if ((i1 == 0 && j1 == 0) || (i + i1 < 0 || i + i1 >= height || j + j1 < 0 || j + j1 >= width))
                                continue;
                            if (field[i + i1, j + j1] == bombCell)
                                countBomb++;
                        }
                    }

                    if (countBomb != 0)
                        field[i, j] = countBomb.ToString();
                }
            }
            return field;
        }
    }
}
