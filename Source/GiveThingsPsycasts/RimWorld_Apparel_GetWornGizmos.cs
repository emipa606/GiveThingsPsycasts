using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace GiveThingsPsycasts
{
    [HarmonyPatch(typeof(Apparel), "GetWornGizmos")]
    public static class RimWorld_Apparel_GetWornGizmos
    {
        [HarmonyPostfix]
        public static void ApparelGizmosFromComps(Apparel __instance, ref IEnumerable<Gizmo> __result)
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
            gizmos.AddRange(__instance.GetComps<CompGiveThingsPsycasts>().SelectMany(comp => comp.CompGetGizmosWorn()));

            __result = gizmos;
        }
    }
}