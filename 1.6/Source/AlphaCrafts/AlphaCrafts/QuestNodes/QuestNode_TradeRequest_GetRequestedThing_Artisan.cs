
using RimWorld;
using RimWorld.QuestGen;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
namespace AlphaCrafts
{
    public class QuestNode_TradeRequest_GetRequestedThing_Artisan : QuestNode
    {
        private static readonly IntRange BaseValueWantedRange = new IntRange(500, 2500);

        private static readonly SimpleCurve ValueWantedFactorFromWealthCurve = new SimpleCurve
    {
        new CurvePoint(0f, 0.3f),
        new CurvePoint(50000f, 1f),
        new CurvePoint(300000f, 2f)
    };

        private static Dictionary<ThingDef, int> requestCountDict = new Dictionary<ThingDef, int>();

        [NoTranslate]
        public SlateRef<string> storeThingAs;

        [NoTranslate]
        public SlateRef<string> storeThingCountAs;

        [NoTranslate]
        public SlateRef<string> storeMarketValueAs;

        [NoTranslate]
        public SlateRef<string> storeHasQualityAs;

        public SlateRef<List<ThingDef>> dontRequest;

        private static int RandomRequestCount(ThingDef thingDef, Map map)
        {
            Rand.PushState(Find.TickManager.TicksGame ^ thingDef.GetHashCode() ^ 0x343820DB);
            float num = BaseValueWantedRange.RandomInRange;
            Rand.PopState();
            num *= ValueWantedFactorFromWealthCurve.Evaluate(map.wealthWatcher.WealthTotal);
            return ThingUtility.RoundedResourceStackCount(Mathf.Max(1, Mathf.RoundToInt(num / thingDef.BaseMarketValue)));
        }

        private static bool TryFindRandomRequestedThingDef(Map map, out ThingDef thingDef, out int count, List<ThingDef> dontRequest)
        {
            requestCountDict.Clear();
            Func<ThingDef, bool> globalValidator = delegate (ThingDef td)
            {
                
                if (!td.alwaysHaulable)
                {
                    return false;
                }
                if (td.thingCategories?.Contains(InternalDefOf.AC_ArtisanProducts)!=true)
                {
                    return false;
                }
                
                int num = RandomRequestCount(td, map);
                requestCountDict.Add(td, num);
                
                return (dontRequest.NullOrEmpty() || !dontRequest.Contains(td)) ? true : false;
            };
            if (ThingSetMakerUtility.allGeneratableItems.Where((ThingDef td) => globalValidator(td)).TryRandomElement(out thingDef))
            {
                count = requestCountDict[thingDef];
                return true;
            }
            count = 0;
            return false;
        }

        protected override void RunInt()
        {
            Slate slate = QuestGen.slate;
            if (TryFindRandomRequestedThingDef(slate.Get<Map>("map"), out ThingDef thingDef, out int count, dontRequest.GetValue(slate)))
            {
                slate.Set(storeThingAs.GetValue(slate), thingDef);
                slate.Set(storeThingCountAs.GetValue(slate), count);
                slate.Set(storeMarketValueAs.GetValue(slate), thingDef.GetStatValueAbstract(StatDefOf.MarketValue) * (float)count);
                slate.Set(storeHasQualityAs.GetValue(slate), thingDef.HasComp(typeof(CompQuality)));
            }
        }

        protected override bool TestRunInt(Slate slate)
        {
            if (TryFindRandomRequestedThingDef(slate.Get<Map>("map"), out ThingDef thingDef, out int count, dontRequest.GetValue(slate)))
            {
                slate.Set(storeThingAs.GetValue(slate), thingDef);
                slate.Set(storeThingCountAs.GetValue(slate), count);
                slate.Set(storeMarketValueAs.GetValue(slate), thingDef.GetStatValueAbstract(StatDefOf.MarketValue) * (float)count);
                return true;
            }
            return false;
        }
    }
}