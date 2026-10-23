using RimWorld;
using UnityEngine;
using Verse;

namespace SadSeal.WorkManager.Core
{
    public class ScheduleManager : MapComponent
    {
        private bool isDirty = true;
        public void MarkDirty() => isDirty = true;

        private static TraitDef nightOwlTrait;
        private static TraitDef NightOwlTrait => nightOwlTrait ??= DefDatabase<TraitDef>.GetNamedSilentFail("NightOwl");

        public ScheduleManager(Map map) : base(map)
        {
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (Find.TickManager.CurTimeSpeed == TimeSpeed.Paused)
            {
                return;
            }

            var settings = WorkManagerMod.Settings;
            if (settings == null || !settings.EnableWorkManager || !settings.ManageWorkSchedule)
            {
                return;
            }

            int intervalTicks = Mathf.Clamp(settings.ScheduleUpdateIntervalHours, 1, 12) * 2500;
            if (isDirty || (Find.TickManager.TicksGame + map.Index * 59) % intervalTicks == 0)
            {
                isDirty = false;
                UpdateSchedules();
            }
        }

        public void UpdateSchedules()
        {
            if (map == null || map.mapPawns == null) return;

            var freeColonists = map.mapPawns.FreeColonists;
            if (freeColonists == null || freeColonists.Count == 0) return;

            var comp = WorkManagerGameComponent.Instance;
            var settings = WorkManagerMod.Settings;

            for (int i = 0; i < freeColonists.Count; i++)
            {
                var pawn = freeColonists[i];
                if (pawn == null || pawn.Dead || pawn.timetable == null || pawn.story?.traits == null) continue;
                if (comp != null && !comp.IsPawnScheduleEnabled(pawn)) continue;

                bool isNightOwl = settings.SupportNightOwls && NightOwlTrait != null && pawn.story.traits.HasTrait(NightOwlTrait);

                for (int hour = 0; hour < 24; hour++)
                {
                    TimeAssignmentDef targetAssignment = isNightOwl ? GetNightOwlAssignment(hour) : GetDayColonistAssignment(hour);
                    if (pawn.timetable.GetAssignment(hour) != targetAssignment)
                    {
                        pawn.timetable.SetAssignment(hour, targetAssignment);
                    }
                }
            }
        }

        private static TimeAssignmentDef GetNightOwlAssignment(int hour)
        {
            if (hour >= 23 || hour <= 6) return TimeAssignmentDefOf.Work;
            if (hour >= 7 && hour <= 9) return TimeAssignmentDefOf.Joy;
            if (hour == 10) return TimeAssignmentDefOf.Anything;
            if (hour >= 11 && hour <= 17) return TimeAssignmentDefOf.Sleep;
            return TimeAssignmentDefOf.Anything;
        }

        private static TimeAssignmentDef GetDayColonistAssignment(int hour)
        {
            if (hour >= 22 || hour <= 5) return TimeAssignmentDefOf.Sleep;
            if (hour == 6 || hour == 7) return TimeAssignmentDefOf.Joy;
            if (hour >= 8 && hour <= 16) return TimeAssignmentDefOf.Work;
            if (hour == 17 || hour == 18) return TimeAssignmentDefOf.Joy;
            return TimeAssignmentDefOf.Anything;
        }
    }
}
