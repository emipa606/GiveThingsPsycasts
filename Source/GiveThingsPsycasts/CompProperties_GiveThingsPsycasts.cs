using Verse;

namespace GiveThingsPsycasts;

public class CompProperties_GiveThingsPsycasts : CompProperties
{
    public string PsycastDefName;

    public CompProperties_GiveThingsPsycasts()
    {
        compClass = typeof(CompGiveThingsPsycasts);
    }
}