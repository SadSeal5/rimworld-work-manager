using HarmonyLib;
using SadSeal.WorkManager.UI;
using UnityEngine;
using Verse;

namespace SadSeal.WorkManager
{
    public class WorkManagerMod : Mod
    {
        public static WorkManagerMod Instance { get; private set; }
        public static WorkManagerSettings Settings { get; private set; }

        public WorkManagerMod(ModContentPack content) : base(content)
        {
            Instance = this;
            Settings = GetSettings<WorkManagerSettings>();

            var harmony = new Harmony("sadseal.workmanager");
            harmony.PatchAll();

            Log.Message("[SadSeal's Work Manager] Initialized successfully.");
        }

        public override string SettingsCategory()
        {
            return "WorkManager_ModTitle".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            WorkManagerSettingsDrawer.DrawSettings(inRect, Settings);
            base.DoSettingsWindowContents(inRect);
        }
    }
}
