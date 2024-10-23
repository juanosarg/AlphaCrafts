
using System.Collections.Generic;
using RimWorld;
using Verse;
namespace AlphaCrafts
{
    public class CompProperties_LabelByIngredients_Inverted : CompProperties
    {
        public string prefix = "";
        public ThingDef ignoredIngredient;
      
        public CompProperties_LabelByIngredients_Inverted()
        {
            compClass = typeof(CompLabelByIngredients_Inverted);
        }

       
    }
}