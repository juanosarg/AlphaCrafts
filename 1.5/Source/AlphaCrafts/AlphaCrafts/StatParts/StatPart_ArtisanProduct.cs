
using RimWorld;
using Verse;

namespace AlphaCrafts
{

    public class StatPart_ArtisanProduct : StatPart
    {
       
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing)
            {
                if (req.Thing.def.thingCategories?.Contains(InternalDefOf.AC_ArtisanProducts) == true)
                {
                    val *= AlphaCrafts_Mod.settings.AC_MarketValueModifier;
                }
                    
                
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing)
            {
                if (req.Thing.def.thingCategories?.Contains(InternalDefOf.AC_ArtisanProducts) == true)
                {
                    return "AC_StatsReport_ArtisanProduct".Translate(AlphaCrafts_Mod.settings.AC_MarketValueModifier.ToString());
                }
                   
                   
                
            }
            return null;
        }
    }
}