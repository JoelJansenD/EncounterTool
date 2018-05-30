using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterTool.Encounters
{
    class Relationship
    {

        public int ID;
        public string Description;
        public bool HasTarget;
        public Monster Target;

        public override string ToString()
        {
            if (HasTarget)
            {
                return Util.ReplaceFirst(Description, "{#}", Target.Name);
            }

            return Description;
        }
    }
}
