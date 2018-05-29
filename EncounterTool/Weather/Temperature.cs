using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterTool.Weather
{
    class Temperature
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int On { get; set; }
        public string[] Rolls { get; set; }

        public string WriteText()
        {
            if(Rolls == null)
            {
                return Text;
            }

            Random rand = new Random();
            string text = Text;

            foreach (string roll in Rolls)
            {
                int total = Util.RollDice(roll);
                text = Util.ReplaceFirst(text, "[$]", total.ToString());
            }

            return text;
        }
    }
}
