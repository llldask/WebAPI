using System.Text;

namespace WebApplication2.Models
{

    public class CodeGenerator
    {
        private static Random rnd = new Random();
        private static int codeStartLenght = 8;
        private static int codeMiddleLenght = 4;
        private static int codeMiddleBlockCount = 3;
        private static int codeEndLenght = 12;
        private static string symbolSet = "abcdefghjiklmnopqrstuvwxyz0123456789";

        public static string GenerateCode()
        {
            StringBuilder sb = new StringBuilder(codeStartLenght + codeMiddleLenght * codeMiddleBlockCount + codeEndLenght);
            sb.Append(GeneratePartCode(codeStartLenght));
            sb.Append("-");
            for (int i = 0; i < codeMiddleBlockCount; i++)
            {
                sb.Append(GeneratePartCode(codeMiddleLenght));
                sb.Append("-");
            }
            sb.Append(GeneratePartCode(codeEndLenght));
            return sb.ToString();
        }

        private static string GeneratePartCode(int lenght)
        {
            StringBuilder sb = new StringBuilder(lenght);
            for (int i = 0; i < lenght; i++)
                sb.Append(symbolSet[rnd.Next(symbolSet.Length)]);
            return sb.ToString();
        }

    }
}

