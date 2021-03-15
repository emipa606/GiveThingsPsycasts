using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace GiveThingsPsycasts
{
    [HarmonyPatch(typeof(Pawn_ApparelTracker), "GetGizmos")]
    public static class RimWorld_Pawn_ApparelTracker_GetGizmos
    {
        [HarmonyPostfix]
        public static void ApparelGizmosFromComps(Pawn_ApparelTracker __instance, ref IEnumerable<Gizmo> __result)
        {
            if (__instance == null)
            {
                return;
            }

            if (__result == null)
            {
                return;
            }

            var gizmos = new List<Gizmo>(__result);
            var hediffs = __instance.pawn.health?.hediffSet;
            if (hediffs == null)
            {
                return;
            }

            foreach (var hediff in hediffs.hediffs)
            {
                var psycastHediff = hediff.TryGetComp<CompGiveHediffsPsycasts>();
                if (psycastHediff == null)
                {
                    continue;
                }

                gizmos.AddRange(psycastHediff.CompGetGizmosWorn());
            }

            __result = gizmos;
        }
    }
}