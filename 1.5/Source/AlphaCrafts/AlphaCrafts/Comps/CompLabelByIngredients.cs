
using Verse;
using System;
using RimWorld;
using System.Collections.Generic;
using System.Linq;



namespace AlphaCrafts
{
    class CompLabelByIngredients : ThingComp
    {
        CompIngredients ingredients = null;

        public CompProperties_LabelByIngredients Props
        {
            get
            {
                return (CompProperties_LabelByIngredients)this.props;
            }
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            if (ingredients == null) {            
                ingredients = this.parent.TryGetComp<CompIngredients>();
            }

        }

        public override string TransformLabel(string label)
        {
            if (ingredients != null && !ingredients.ingredients.NullOrEmpty())
            {
                if (!Props.overrides.NullOrEmpty())
                {
                    ThingDef thingDef = ingredients.ingredients.First();
                    if (thingDef!=null && Props.overrides.ContainsKey(thingDef))
                    {
                        return Props.overrides[thingDef] + " " + label;
                    }
                    return ingredients.ingredients.First().LabelCap + " " + label;
                }
                else
                {
                    return ingredients.ingredients.First().LabelCap + " " + label;
                }
            }
            return label;

        }

    }
}

