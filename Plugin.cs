using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
namespace LumiCompany
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
       
        private static BaseUnityPlugin instance;
        private void Awake()
        {
            if(instance == null) { 
                instance = this;
            }
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Logger.LogInfo($"OH NONNONNONOONOO ahah");
            var harmony = new Harmony("LumiCompany");
            harmony.PatchAll(typeof(BaseUnityPlugin));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            //search for a canva object
            GameObject canvas = GameObject.Find("Canvas");
            Logger.LogInfo($"Canvas found");
            Logger.LogInfo(canvas);

        }

    }

    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void infinitSprintPatch(ref float ___sprintMeter)
        {
            // Prevent stamina from decreasing
            ___sprintMeter = 1f;


        }
    }

}
