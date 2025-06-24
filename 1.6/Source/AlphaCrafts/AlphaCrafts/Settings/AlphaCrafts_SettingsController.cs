using RimWorld;
using UnityEngine;
using Verse;


namespace AlphaCrafts
{




    public class AlphaCrafts_Mod : Mod
    {
        public static AlphaCrafts_Settings settings;

        public AlphaCrafts_Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<AlphaCrafts_Settings>();
        }
        public override string SettingsCategory() => "Alpha Crafts";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }





    }
}

