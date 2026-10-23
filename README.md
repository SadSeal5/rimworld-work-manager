# 💼 SadSeal's Work Manager for RimWorld (1.6 & 1.7)

[![RimWorld 1.6 & 1.7 (.NET 10)](https://img.shields.io/badge/RimWorld-1.6%20%7C%201.7%20(.NET%2010)-brightgreen.svg)](#)
[![Language](https://img.shields.io/badge/Language-C%23-blue.svg)](#)
[![License](https://img.shields.io/badge/License-MIT-orange.svg)](#)

**SadSeal's Work Manager** is a complete, high-performance re-architecture of the classic RimWorld Work Manager mod, engineered from scratch for modern RimWorld versions including **RimWorld 1.7 (.NET 10)** and **RimWorld 1.6**.

Vanilla colony management requires tedious micro-management of the 1–4 manual work priorities and 24-hour schedules. Original work manager mods suffered from severe TPS degradation due to heavy runtime LINQ allocations, heap thrashing, and unoptimized 64-tick polling loops. **SadSeal's Work Manager** eliminates all GC pressure with a zero-allocation flat scoring architecture and throttled ticks while delivering intelligent priority assignments and circadian rhythm automation.

---

## ✨ Features

* **🚀 Automated Dynamic Work Priorities (1–4):**
  * Evaluates every colonist's skill levels (0–20), passions (+30 points for burning passion, +15 points for interested), physical capacities (manipulation, sight, moving, consciousness), traits, and ideology roles.
  * Dynamically sets manual priorities from 1 (highest emergency / passion priority) to 4 (secondary chores) without player intervention.
* **🎯 Dedicated Specialist Quotas:**
  * Configurable dedicated worker targets per map for critical colonial roles:
    * 🩺 **Doctors:** Highest medical skill pawns prioritized for emergency medical tending.
    * 🍳 **Cooks:** Prevents food poisoning by assigning high-cooking colonists.
    * 🔬 **Researchers:** Keeps benches continuously staffed by intellectual specialists.
    * 🗝️ **Wardens:** Social specialists dedicated to prison recruitment and colony diplomacy.
    * 🐾 **Handlers:** Animal specialists dedicated to training and taming without stalling.
* **⚡ Idle Pawn Redirection:**
  * When a specialized colonist has no active tasks in their primary work types, the system temporarily elevates hauling and cleaning priorities so colonists never wander idle.
* **🌙 24-Hour Circadian Scheduling & Night Owl Automation:**
  * Runs on in-game hourly intervals (2,500 ticks) instead of high-frequency tick polling.
  * **Day Colonists:** Balanced 8-hour sleep shifts, synchronized recreation blocks (morning and evening for social mood boosts), and structured work blocks.
  * **Night Owls:** Detects the Night Owl trait and automatically shifts sleep to daytime (11:00–18:00) and recreation/work to night (23:00–07:00), guaranteeing permanent +16 mood bonuses.
* **🖥️ Seamless Work & Schedule Tab Integration:**
  * Adds custom toggle columns (`Auto-Priorities` & `Auto-Schedule`) to the Work tab and Schedule tab.
  * Allows per-colonist automation toggles with a single click.
  * Header buttons in the Work tab provide 1-click mod settings access and manual refresh.
* **⚙️ Complete In-Game Mod Settings & Quick Presets:**
  * **Balanced (Default):** 500-tick updates, balanced specialist quotas, idle redirection enabled.
  * **High Performance (Ultra TPS):** 1,500-tick updates, ideal for gigantic 50+ pawn colonies.
  * **Strict Specialist:** High thresholds, strictly limits roles to dedicated experts.
  * **Reset to Defaults:** 1-click restore to original configurations.
* **🌐 Multilingual Support:** Complete English and Turkish (*Türkçe*) localization.

---

## 🛠️ Performance & Engine Design

- **Zero Runtime Allocations:** Discards `LordKuper.Common.dll` and all LINQ query chains (`.Where().ToList()`). All scoring and ranking use static pre-allocated reusable arrays.
- **Throttled Tick Intervals:** Priority balancing operates every 500 ticks (configurable 100–5,000), while schedule management operates strictly on hour boundaries (2,500 ticks).
- **Persistent State:** Per-pawn manual overrides and disabled automation IDs are serialized directly with `Scribe_Collections` (`HashSet<int>`), surviving save/load cycles without data loss.

---

## 📋 Requirements

* **RimWorld:** `1.6` or `1.7` (.NET 10)
* **Harmony** (`brrainz.harmony`)

---

## 📦 Installation

### As Standalone Mod:
1. Copy the `WorkManager` directory into your RimWorld `Mods/` directory:
   `RimWorld/Mods/WorkManager`
2. Activate **Harmony** first, then activate **SadSeal's Work Manager** in the mod manager.

### As Part of SadSeal's Mega Mod:
* This module is also fully integrated into **SadSeal's Mega Mod** under the **Work Manager** (`İş Yöneticisi`) tab in Mod Settings.

---

## 📜 License

Released under the [MIT License](LICENSE).
Original inspiration from *Work Manager* by LordKuper.
Re-architected and maintained by SadSeal5.
