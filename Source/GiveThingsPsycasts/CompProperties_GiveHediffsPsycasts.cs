using Verse;

namespace GiveThingsPsycasts
{
    public class CompProperties_GiveHediffsPsycasts : HediffCompProperties
    {
        public string PsycastDefName;

        public CompProperties_GiveHediffsPsycasts()
        {
            compClass = typeof(CompGiveHediffsPsycasts);
        }
    }
}