using System.Collections.Generic;
using RimWorld;
using Verse;

namespace GiveThingsPsycasts
{
    public class CompGiveHediffsPsycasts : HediffComp
    {
        private AbilityDef definedPsycastDef;
        private bool VerifyAbilityDef = true;

        private CompProperties_GiveHediffsPsycasts Props => (CompProperties_GiveHediffsPsycasts) props;

        private Pawn GetWearer => parent.pawn;

        private bool IsWorn => GetWearer != null;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            if (!VerifyAbilityDef)
            {
                return;
            }

            definedPsycastDef = Main.verifyPsycastDef(Props.PsycastDefName);
            VerifyAbilityDef = false;
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

            if (!Main.shouldShowGizmo(owner))
            {
                yield break;
            }

            Main.resetPsycastLevel(owner);

            var ability = new Psycast(owner, definedPsycastDef);
            yield return new Command_Psycast(ability);
        }
    }
}