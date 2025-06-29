using System.Collections.Generic;
using RimWorld;
using Verse;

namespace GiveThingsPsycasts;

public class CompGiveThingsPsycasts : ThingComp
{
    private AbilityDef definedPsycastDef;

    private CompProperties_GiveThingsPsycasts Props => (CompProperties_GiveThingsPsycasts)props;

    private Pawn GetWearer
    {
        get
        {
            if (ParentHolder is Pawn_ApparelTracker or Pawn_EquipmentTracker)
            {
                return (Pawn)ParentHolder.ParentHolder;
            }

            return null;
        }
    }

    private bool IsWorn => GetWearer != null;

    public override void Initialize(CompProperties props)
    {
        base.Initialize(props);
        definedPsycastDef = Main.VerifyPsycastDef(Props.PsycastDefName);
    }

    public IEnumerable<Gizmo> CompGetGizmosWorn()
    {
        if (definedPsycastDef == null)
        {
            yield break;
        }

        if (!IsWorn)
        {
            yield break;
        }

        var owner = GetWearer;

        if (!Main.ShouldShowGizmo(owner))
        {
            yield break;
        }

        Main.ResetPsycastLevel(owner);

        var ability = new Psycast(owner, definedPsycastDef);
        yield return new Command_Psycast(ability, owner);
    }
}