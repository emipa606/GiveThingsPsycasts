using System.Collections.Generic;
using RimWorld;
using Verse;

namespace GiveThingsPsycasts
{
    public class CompGiveThingsPsycasts : ThingComp
    {
        private AbilityDef definedPsycastDef;

        private CompProperties_GiveThingsPsycasts Props => (CompProperties_GiveThingsPsycasts) props;

        private Pawn GetWearer
        {
            get
            {
                if (ParentHolder is Pawn_ApparelTracker)
                {
                    return (Pawn) ParentHolder.ParentHolder;
                }

                if (ParentHolder is Pawn_EquipmentTracker)
                {
                    return (Pawn) ParentHolder.ParentHolder;
                }

                return null;
            }
        }

        private bool IsWorn => GetWearer != null;

        public override void Initialize(CompProperties props)
        {
            base.Initialize(props);
            if (string.IsNullOrEmpty(Props.PsycastDefName))
            {
                Log.ErrorOnce($"[GiveThingsPsycasts] No defined psycast defName for {parent.def.defName}",
                    GetHashCode());
                return;
            }

            definedPsycastDef = DefDatabase<AbilityDef>.GetNamedSilentFail(Props.PsycastDefName);
            if (definedPsycastDef != null)
            {
                return;
            }

            Log.ErrorOnce(
                $"[GiveThingsPsycasts] Could not find psycast with defName {Props.PsycastDefName} for {parent.def.defName}",
                GetHashCode());
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
            if (!Find.Selector.SelectedObjects.Contains(owner) || !owner.IsColonistPlayerControlled)
            {
                yield break;
            }

            owner.psychicEntropy ??= new Pawn_PsychicEntropyTracker(owner);
            if (owner.psychicEntropy.CurrentPsyfocus < 0)
            {
                owner.psychicEntropy.OffsetPsyfocusDirectly(owner.psychicEntropy.CurrentPsyfocus * -1);
            }

            var ability = new Psycast(owner, definedPsycastDef);
            yield return new Command_Psycast(ability);
        }
    }
}