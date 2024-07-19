namespace WebApplication2.Models
{
    public class Move
    {
        public static (bool, string) StringUserMove(string userField, string bombField, int x, int y, int height, int weight)
        {
            int n = weight * y + x;
            string elemBombField = bombField[n].ToString();

            if (elemBombField.CompareTo(PlaySymbol.bombСell) == 0)
            {
                return (false, bombField);
            }
            else if (elemBombField.CompareTo(PlaySymbol.bombСell) != 0 && elemBombField.CompareTo(PlaySymbol.emptyСellFull) != 0)
            {
                userField = userField.Remove(n, 1).Insert(n, bombField[n].ToString());
            }
            else if (elemBombField.CompareTo(PlaySymbol.emptyСellFull) == 0)
            {
                var userFieldArray = Converter.StringToTwoDimensional(userField, height, weight);
                var bombFieldArray = Converter.StringToTwoDimensional(bombField, height, weight);
                userFieldArray[y, x] = PlaySymbol.emptyСellFull;
                userFieldArray = Filling(userFieldArray, bombFieldArray, x, y);
                userField = Converter.TwoDimensionalToString(userFieldArray);
            }

            if (CheckWin(userField, bombField))
                return (false, WinReplaseSymbol(bombField));


            return (true, userField);
        }

        public static bool OpenCell(string userField, int x, int y, int weight)
        {
            int n = weight * y + x;
            if (userField[n].ToString().CompareTo(PlaySymbol.emptyСellUser) != 0)
                return true;
            return false;
        }
        private static String[,] Filling(String[,] userField, String[,] bombField, int x, int y)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((y, x));
            int height = userField.GetLength(0);
            int width = userField.Length / userField.GetLength(0);

            while (stack.Count > 0)
            {
                var turple = stack.Pop();

                for (int i = -1; i <= 1; i += 2)
                {
                    CellCheck(turple.Item2 + i, turple.Item1, turple.Item2 + i, width, userField, bombField, stack);
                }
                for (int i = -1; i <= 1; i += 2)
                {
                    CellCheck(turple.Item1 + i, turple.Item1 + i, turple.Item2, height, userField, bombField, stack);
                }

            }

            return userField;

        }

        private static void CellCheck(int verifiable, int item1, int item2, int lim, String[,] userField, String[,] bombField, Stack<(int, int)> stack)
        {
            if (verifiable >= 0 && verifiable < lim && userField[item1, item2] == PlaySymbol.emptyСellUser)
            {
                if (bombField[item1, item2] != PlaySymbol.bombСell)
                    userField[item1, item2] = bombField[item1, item2];
                if (bombField[item1, item2] == PlaySymbol.emptyСellFull)
                    stack.Push((item1, item2));
            }
        }

        private static bool CheckWin(string userField, string bombField)
        {
            for (int i = 0; i < userField.Length; i++)
            {
                if (userField[i].ToString().CompareTo(PlaySymbol.emptyСellUser) == 0 && bombField[i].ToString().CompareTo(PlaySymbol.bombСell) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static string WinReplaseSymbol(string bombField)
        {
            bombField = bombField.Replace(PlaySymbol.bombСell, PlaySymbol.bombWinСell);
            return bombField;
        }
    }
}
