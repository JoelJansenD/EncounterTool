using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterTool.Encounters
{
    class Monster
    {
        public int ID;
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

        public Monster GetCopy()
        {
            Monster copy = new Monster()
            {
                ID = ID,
                Name = Name,
                Type = Type,
                CR = CR,
                AppropriateMonsters = AppropriateMonsters
            };

            return copy;
        }
    }
}
