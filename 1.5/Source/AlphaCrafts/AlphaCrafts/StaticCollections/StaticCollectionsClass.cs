
using Verse;
using System;
using RimWorld;
using System.Collections.Generic;
using System.Linq;


namespace AlphaCrafts
{
    [StaticConstructorOnStartup]
    public static class StaticCollections
    {

        public static Dictionary<ThingDef, int> yogurtOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> oilOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> perfumeOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> butterOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> vinegarOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> flourOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> chipsOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> zestOffsets = new Dictionary<ThingDef, int>();
        public static Dictionary<ThingDef, int> pureeOffsets = new Dictionary<ThingDef, int>();

        static StaticCollections()
        {
            List<YogurtOffsets> allYogurtLists = DefDatabase<YogurtOffsets>.AllDefsListForReading.ToList();
            foreach (YogurtOffsets individualList in allYogurtLists)
            {

                yogurtOffsets.AddRange(individualList.fruitAndOffsetList);
            }

            List<OilOffsets> allOilLists = DefDatabase<OilOffsets>.AllDefsListForReading.ToList();
            foreach (OilOffsets individualList in allOilLists)
            {

                oilOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }

            List<PerfumeOffsets> allPerfumeLists = DefDatabase<PerfumeOffsets>.AllDefsListForReading.ToList();
            foreach (PerfumeOffsets individualList in allPerfumeLists)
            {

                perfumeOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }
            List<ButterOffsets> allButterLists = DefDatabase<ButterOffsets>.AllDefsListForReading.ToList();
            foreach (ButterOffsets individualList in allButterLists)
            {

                butterOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }
            List<VinegarOffsets> allVinegarLists = DefDatabase<VinegarOffsets>.AllDefsListForReading.ToList();
            foreach (VinegarOffsets individualList in allVinegarLists)
            {

                vinegarOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }
            List<FlourOffsets> allFlourLists = DefDatabase<FlourOffsets>.AllDefsListForReading.ToList();
            foreach (FlourOffsets individualList in allFlourLists)
            {

                flourOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }
            List<ChipsOffsets> allChipsLists = DefDatabase<ChipsOffsets>.AllDefsListForReading.ToList();
            foreach (ChipsOffsets individualList in allChipsLists)
            {

                chipsOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }
            List<ZestOffsets> allZestLists = DefDatabase<ZestOffsets>.AllDefsListForReading.ToList();
            foreach (ZestOffsets individualList in allZestLists)
            {

                zestOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }
            List<PureeOffsets> allPureeLists = DefDatabase<PureeOffsets>.AllDefsListForReading.ToList();
            foreach (PureeOffsets individualList in allPureeLists)
            {

                pureeOffsets.AddRange(individualList.ingredientsAndOffsetList);
            }
        }




    }
}
