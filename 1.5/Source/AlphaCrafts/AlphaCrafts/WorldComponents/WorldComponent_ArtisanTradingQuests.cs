using RimWorld;
using RimWorld.Planet;
using Verse;
using RimWorld.QuestGen;
using AlphaCrafts;

namespace AlphaCrafts
{



    public class WorldComponent_ArtisanTradingQuests : WorldComponent
    {
        public int tickCounter;
        public int ticksToNextQuest = 60000 * 14;


        public WorldComponent_ArtisanTradingQuests(World world) : base(world)
        {
        }

        public override void FinalizeInit()
        {
            base.FinalizeInit();



        }

        public override void WorldComponentTick()
        {
            base.WorldComponentTick();

            if (!AlphaCrafts_Mod.settings.AC_DisableQuests)
            {

                if (tickCounter > ticksToNextQuest)
                {

                    Slate slate = new Slate();

                    if (InternalDefOf.AC_ArtisanTradeRequest.CanRun(slate))
                    {
                        Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(InternalDefOf.AC_ArtisanTradeRequest, slate);

                        QuestUtility.SendLetterQuestAvailable(quest);
                        ticksToNextQuest = (int)(60000 * Rand.RangeInclusive(15, 30) * AlphaCrafts_Mod.settings.AC_QuestRate);
                    }
                   
                    tickCounter = 0;




                }
                tickCounter++;
            }







        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref this.tickCounter, nameof(this.tickCounter));
            Scribe_Values.Look(ref this.ticksToNextQuest, nameof(this.ticksToNextQuest));
        }
    }
}
