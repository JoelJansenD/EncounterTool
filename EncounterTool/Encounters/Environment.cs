using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterTool.Encounters
{
    class Environment
    {
        public int ID { get; private set; }
        public string Name;
        public int Temp;
        public Monster[] AppropriateMonsters;
    }
}
