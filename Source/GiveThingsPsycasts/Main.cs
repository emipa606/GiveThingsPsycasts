using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace GiveThingsPsycasts;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        var harmony = new Harmony("Mlie.GiveThingsPsycasts");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    public static void resetPsycastLevel(Pawn pawn)
    {
        pawn.psychicEntropy ??= new Pawn_PsychicEntropyTracker(pawn);
        if (pawn.psychicEntropy.CurrentPsyfocus < 0)
        {
            pawn.psychicEntropy.OffsetPsyfocusDirectly(pawn.psychicEntropy.CurrentPsyfocus * -1);
        }
    }

    public static bool shouldShowGizmo(Pawn pawn)
    {
        return Find.Selector.SelectedObjects.Contains(pawn) && pawn.IsColonistPlayerControlled;
    }

    public static AbilityDef verifyPsycastDef(string defName)
    {
        if (string.IsNullOrEmpty(defName))
        {
            return null;
        }

        var returnValue = DefDatabase<AbilityDef>.GetNamedSilentFail(defName);
        if (returnValue != null)
        {
            return returnValue;
        }

        Log.ErrorOnce(
            $"[GiveThingsPsycasts] Could not find psycast with defName {defName}",
            defName.GetHashCode());
        return null;
    }
}