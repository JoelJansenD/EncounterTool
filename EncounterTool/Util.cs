using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterTool
{
    class Util
    {
        public static string ReplaceFirst(string input, string search, string replace)
        {
            int position = input.IndexOf(search);
            if (position < 0)
            {
                return input;
            }

            return input.Substring(0, position) + replace + input.Substring(position + search.Length);
        }

        public static int RollDice(string input)
        {
            Random rand = new Random();
            string[] rollParams = input.Split('d');

            int dieCount = Convert.ToInt32(rollParams[0]);
            int dieSize = Convert.ToInt32(rollParams[1]);

            int total = 0;
            for (int i = 0; i < dieCount; i++)
            {
                total += rand.Next(1,dieSize + 1);
            }

            return total;
        }
    }
}
