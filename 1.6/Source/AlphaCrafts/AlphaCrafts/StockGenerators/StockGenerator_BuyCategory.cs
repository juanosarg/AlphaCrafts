
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.Planet;
using Verse;
namespace AlphaCrafts
{
    public class StockGenerator_BuyCategory : StockGenerator
    {
        public ThingCategoryDef category;

        public override IEnumerable<Thing> GenerateThings(PlanetTile forTile, Faction faction = null)
        {
            return Enumerable.Empty<Thing>();
        }

        public override bool HandlesThingDef(ThingDef thingDef)
        {
            if (thingDef.thingCategories != null)
            {
                return thingDef.thingCategories.Contains(category);
            }
            return false;
        }

        public override Tradeability TradeabilityFor(ThingDef thingDef)
        {
            if (thingDef.tradeability == Tradeability.None || !HandlesThingDef(thingDef))
            {
                return Tradeability.None;
            }
            return Tradeability.Sellable;
        }
    }
}