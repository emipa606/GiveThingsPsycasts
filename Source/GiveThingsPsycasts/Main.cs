using System.Reflection;
using HarmonyLib;
using Verse;

namespace GiveThingsPsycasts
{
    [StaticConstructorOnStartup]
    internal class Main
    {
        static Main()
        {
            var harmony = new Harmony("Mlie.GiveThingsPsycasts");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}