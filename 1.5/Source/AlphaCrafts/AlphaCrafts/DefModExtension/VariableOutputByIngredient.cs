using Verse;
using System.Collections.Generic;

namespace AlphaCrafts
{
    public class VariableOutputByIngredient : DefModExtension
    {
        public ThingDef baseline;
        public List<ThingDef> exclusions = new List<ThingDef>();
        public bool useCap = false;
        public float capPriceInfluenceMultiplier;
    }
}