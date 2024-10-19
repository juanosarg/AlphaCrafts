
using System.Collections.Generic;
using RimWorld;
using Verse;
namespace AlphaCrafts
{
    public class CompProperties_LabelByIngredients : CompProperties
    {
        public bool fullReplace = false;
        public Dictionary<ThingDef, string> overrides = new Dictionary<ThingDef, string>();

        public CompProperties_LabelByIngredients()
        {
            compClass = typeof(CompLabelByIngredients);
        }

       
    }
}