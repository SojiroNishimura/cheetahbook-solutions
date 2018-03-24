using System;

namespace CheetahBook
{
    // SRM484
    public class NumberMagicEasy
    {
        public NumberMagicEasy()
        {
            var reader = new System.IO.StreamReader("Inputs_NumberMagicEasy.txt");
            Console.SetIn(reader);
        }

        public int TheNumber(string answer)
        {
            var cards = new string[] {
                "YYYY",
                "YYYN",
                "YYNY",
                "YYNN",
                "YNYY",
                "YNYN",
                "YNNY",
                "YNNN",
                "NYYY",
                "NYYN",
                "NYNY",
                "NYNN",
                "NNYY",
                "NNYN",
                "NNNY",
                "NNNN"
            };
            for (var i = 0; i < 16; i++)
            {
                if (answer == cards[i]) return i + 1;
            }
            return 0;
        }

        public void Solve()
        {
            Console.WriteLine("NumberMagicEasy");
            var numberMagic = new NumberMagicEasy();
            var input = Console.ReadLine();
            var ans = numberMagic.TheNumber(input);
            Console.WriteLine($"{ans}");
        }
    }
}
