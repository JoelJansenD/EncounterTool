using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterTool.Encounters
{
    class Monster
    {
        public int ID { get; private set; }
        public string Name;
        public string Type;
        public double CR;
        public Monster[] AppropriateMonsters;

        public int GetExperience()
        {
            switch (CR)
            {
                case 0:
                    return 10;
                case 0.125:
                    return 25;
                case 0.25:
                    return 50;
            }

            return 0;
        }
    }
}
