using System;
using BepInEx;
using HarmonyLib;
using DiskCardGame;

namespace RevealRuleBook
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PluginGuid = "nakamo326.inscryption.revealRuleBook";
        private const string PluginName = "RevealRuleBook";
        private const string PluginVersion = "1.0.0";
        void Awake()
        {
            var harmony = new Harmony(PluginGuid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(RuleBookInfo))]
    [HarmonyPatch("FillStatIconPage")]
    public class RevarlRuleBookPatch
    {
        static bool Prefix(RuleBookPageInfo page, int iconIndex)
        {
            SpecialStatIcon iconIndex2 = (SpecialStatIcon)iconIndex;
            page.pageId = iconIndex2.ToString();
            return false;
        }
    }
}

