using ActionGame;
using ActionGame.Chara;
using BepInEx;
using Harmony;

namespace NoVampire
{
    public static class Hooks
    {
        public static void InstallHooks()
        {
            var harmony = HarmonyInstance.Create("meidodev.kk.no-vampire");
            harmony.PatchAll(typeof(Hooks));
        }
        
        [HarmonyPostfix, HarmonyPatch(typeof(CameraStateDefinitionChange), "ModeChange")]
        public static void ModeChangePostHook(CameraStateDefinitionChange __instance, CameraMode mode, ref Player player)
        {
            // Only do something if the CameraMode is FPS and the chara isn't visible
            if (mode == CameraMode.FPS && player.chaCtrl.visibleAll == false) {
                player.chaCtrl.visibleAll = true;
                
                AccessTools.Property(typeof(CameraStateDefinitionChange), "_changedFrameNow").SetValue(__instance, true, null);                
                player.chaCtrl.LateUpdateForce();
            }
        }
    }
}
