using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Pinkcore.Heros.Localization;
using UnityEngine;

namespace RiseOfErosLocalization
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class RiseOfErosLocalization : BasePlugin
    {
        public override void Load()
        {
            Harmony.CreateAndPatchAll(typeof(RiseOfErosLocalization));
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        [HarmonyPrefix, HarmonyPatch(typeof(LocalizationManager), "Pinkcore_Heros_Localization_ILocalizationManager_GetText")]
        public static void GetTextPatch(string term, ref LocalizationLanguage language, LocalizationManager __instance) {
            if (__instance._currentLanguage != LocalizationLanguage.ChineseTraditional)
                __instance._currentLanguage = LocalizationLanguage.ChineseTraditional;
        }
    }
}
