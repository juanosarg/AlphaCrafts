using RimWorld;
using Verse;
namespace AlphaCrafts
{
    public class CompProperties_UseEffectReduceInfections : CompProperties_UseEffect
    {
        public float reduction;

        public CompProperties_UseEffectReduceInfections()
        {
            compClass = typeof(CompUseEffect_ReduceInfections);
        }
    }
}
