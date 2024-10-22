
using RimWorld;
using Verse;


namespace AlphaCrafts
{
    [DefOf]
    public static class InternalDefOf
    {


        public static ThingCategoryDef AC_ArtisanProducts;
        public static QuestScriptDef AC_ArtisanTradeRequest;



        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}
