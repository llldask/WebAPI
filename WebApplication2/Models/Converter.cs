using System.Text;

namespace WebApplication2.Models
{
    public class Converter
    {
        public static string TwoDimensionalToString(String[,] strings)
        {
            StringBuilder sb = new StringBuilder(strings.Length);
            for (int i = 0; i < strings.GetLength(0); i++)
                for (int j = 0; j < strings.Length / strings.GetLength(0); j++)
                    sb.Append(strings[i, j]);
            return sb.ToString();
        }
        public static List<List<String>> TwoDimensionalToList(String[,] strings)
        {
            var resultList = new List<List<String>>();
            for (int i = 0; i < strings.GetLength(0); i++)
            {
                var intermediateList = new List<String>();
                for (int j = 0; j < strings.Length / strings.GetLength(0); j++)
                {
                    intermediateList.Add(strings[i, j]);
                }
                resultList.Add(intermediateList);
            }
            return resultList;
        }

        public static String[,] StringToTwoDimensional(String str, int height, int width)
        {
            var resultArray = new String[height, width];
            int c = 0;
            for (int i = 0; i < resultArray.GetLength(0); i++)
            {
                for (int j = 0; j < resultArray.Length / resultArray.GetLength(0); j++)
                {
                    resultArray[i, j] = str[c].ToString();
                    c++;
                }

            }
            return resultArray;
        }

        public static List<List<String>> StringToList(String str, int height, int width)
        {
            int n = 0;
            var resultList = new List<List<String>>();
            for (int i = 0; i < height; i++)
            {
                var intermediateList = new List<String>();
                for (int j = 0; j < width; j++)
                {
                    intermediateList.Add(str[n].ToString());
                    n++;
                }
                resultList.Add(intermediateList);
            }
            return resultList;
        }
    }
}
