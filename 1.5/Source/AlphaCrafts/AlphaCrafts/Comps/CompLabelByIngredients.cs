
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
        string cachedLabel = "";

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
            if (cachedLabel == "")
            {
                if (ingredients != null && !ingredients.ingredients.NullOrEmpty())
                {
                    if (!Props.overrides.NullOrEmpty())
                    {
                        ThingDef thingDef = ingredients.ingredients.Where(x => Props.exclusions?.Contains(x) != true).First();
                        if (thingDef != null && Props.overrides.ContainsKey(thingDef))
                        {
                            if (Props.fullReplace)
                            {
                                cachedLabel= Props.overrides[thingDef];
                            }
                            else { 
                                cachedLabel= Props.overrides[thingDef] + " " + label; 
                            }

                        }
                        else
                        {
                            cachedLabel = ingredients.ingredients.Where(x => Props.exclusions?.Contains(x) != true).First().LabelCap + " " + label;
                        }
                        
                    }
                    else
                    {
                        cachedLabel= ingredients.ingredients.Where(x => Props.exclusions?.Contains(x) != true).First().LabelCap + " " + label;
                    }
                }


            }
         
            return cachedLabel == "" ? label : cachedLabel;

        }

    }
}

