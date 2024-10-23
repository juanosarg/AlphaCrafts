
using Verse;
using System;
using RimWorld;
using System.Collections.Generic;
using System.Linq;



namespace AlphaCrafts
{
    class CompLabelByIngredients_Inverted : ThingComp
    {
        CompIngredients ingredients = null;
        string cachedLabel = "";

        public CompProperties_LabelByIngredients_Inverted Props
        {
            get
            {
                return (CompProperties_LabelByIngredients_Inverted)this.props;
            }
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            if (ingredients == null)
            {
                ingredients = this.parent.TryGetComp<CompIngredients>();
            }

        }

        public override string TransformLabel(string label)
        {
            if (cachedLabel == "")
            {
                if (ingredients != null && !ingredients.ingredients.NullOrEmpty())
                {
                    
                        cachedLabel = Props.prefix + " " + ingredients.ingredients.Where(x=> x!=Props.ignoredIngredient).First().LabelCap;
                    }
                


            }

            return cachedLabel == "" ? label : cachedLabel;

        }

    }
}

