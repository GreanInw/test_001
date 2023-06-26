using System.Text;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ManualInput();
            AutoInput1To200();
        }

        static void ManualInput()
        {
            Console.Write("Please input : ");
            var value = Console.ReadLine();
            if (!int.TryParse(value, out int newValue))
            {
                Console.WriteLine("Input invalid.");
                return;
            }

            var result = ChangeHelper.Change(newValue);
            Console.WriteLine($"Output : {result.Item1} {result.Item2}");
            ManualInput();
        }

        static void AutoInput1To200()
        {
            var text = new StringBuilder();
            for (int i = 1; i <= 200; i++)
            {
                var result = ChangeHelper.Change(i);
                var resultAsString = $"Input : {i} -> Output : {result.Item1} {result.Item2}";
                text.AppendLine(resultAsString);
                Console.WriteLine(resultAsString);
            }

            File.WriteAllText("D:\\result.txt", text.ToString());
        }
    }

    public class ChangeHelper
    {
        public static (int Coin10, int Coin3) Change(int value)
        {
            for (int coin10 = value / 10; coin10 >= 0; coin10--)
            {
                for (int coin3 = value / 3; coin3 >= 0; coin3--)
                {
                    int totalChange = coin10 * 10 + coin3 * 3;
                    if (totalChange == value)
                    {
                        return (coin10, coin3);
                    }
                }
            }
            return (0, 0);
        }
    }
}