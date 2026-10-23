# 💼 SadSeal's Work Manager for RimWorld (1.6 & 1.7)

[![RimWorld 1.6 & 1.7 (.NET 10)](https://img.shields.io/badge/RimWorld-1.6%20%7C%201.7%20(.NET%2010)-brightgreen.svg)](#)
[![Language](https://img.shields.io/badge/Language-C%23-blue.svg)](#)
[![License](https://img.shields.io/badge/License-MIT-orange.svg)](#)

An unofficial port and modernization of **LordKuper's** beloved [Work Manager](https://steamcommunity.com/sharedfiles/filedetails/?id=2029596262) mod, updated specifically for compatibility with modern RimWorld versions including **RimWorld 1.6** and **RimWorld 1.7 (.NET 10)**.

---

### 🙏 Credits & Acknowledgments

* **Original Mod & Creator:** All credit for the brilliant design, concept, and original UI belongs to **[LordKuper](https://steamcommunity.com/sharedfiles/filedetails/?id=2029596262)**. 
* **Unofficial 1.6 / 1.7 Port:** This project is an unofficial fan port created to allow players to continue enjoying LordKuper's essential mod on modern RimWorld runtime (.NET 10 / 1.7), rewritten with modern lightweight buffers to maintain high TPS in large late-game colonies.
* If you are playing on older versions (1.1 – 1.5), please support and subscribe to the [original Work Manager by LordKuper on Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2029596262).

---

## ✨ Features

* **🚀 Automated Dynamic Work Priorities (1–4):**
  * Evaluates colonist skill levels (0–20), passions (+30 points for burning passion, +15 points for interested), physical capacities (manipulation, sight, moving, consciousness), traits, and ideology roles.
  * Dynamically assigns manual priorities from 1 (highest emergency / passion priority) to 4 (secondary chores) without requiring constant micro-management.
* **🎯 Dedicated Specialist Quotas:**
  * Configurable dedicated worker targets per map for critical colonial roles:
    * 🩺 **Doctors:** Highest medical skill pawns prioritized for emergency medical tending.
    * 🍳 **Cooks:** Prevents food poisoning by assigning high-cooking colonists.
    * 🔬 **Researchers:** Keeps benches continuously staffed by intellectual specialists.
    * 🗝️ **Wardens:** Social specialists dedicated to prison recruitment and colony diplomacy.
    * 🐾 **Handlers:** Animal specialists dedicated to training and taming without stalling.
* **⚡ Idle Pawn Redirection:**
  * When a specialized colonist has no active tasks in their primary work types, the system temporarily elevates hauling and cleaning priorities so colonists stay productive.
* **🌙 24-Hour Circadian Scheduling & Night Owl Automation:**
  * **Day Colonists:** Balanced 8-hour sleep shifts, synchronized recreation blocks (morning and evening for social mood boosts), and structured work blocks.
  * **Night Owls:** Detects the Night Owl trait and automatically shifts sleep to daytime (11:00–18:00) and recreation/work to night (23:00–07:00), maximizing positive mood buffs.
* **🖥️ Seamless Work & Schedule Tab Integration:**
  * Adds custom toggle columns (`Auto-Priorities` & `Auto-Schedule`) to the Work and Schedule tabs.
  * Allows per-colonist automation toggles with a single click.
  * Header buttons in the Work tab provide quick mod settings access and manual refresh.
* **⚙️ Complete In-Game Mod Settings & Presets:**
  * **Presets:** *Balanced (Default)*, *High Performance*, *Strict Specialist*, and *Reset to Defaults*.
  * Customizable update intervals, worker thresholds, and specialist quotas.
* **🌐 Multilingual Support:** Complete English and Turkish (*Türkçe*) localization.

---

## 🛠️ Modernization & Technical Details

- **RimWorld 1.7 (.NET 10) & 1.6 Compatibility:** Recompiled and adapted against modern RimWorld assemblies and runtime environments.
- **Optimized Memory Usage:** Re-engineered priority calculations to use pre-allocated static buffers, eliminating GC heap allocations during periodic updates.
- **Clock-Synchronized Scheduling:** Schedule checks are executed strictly on in-game hour changes (2,500 ticks) to keep simulation overhead minimal.
- **Save Game Safe:** Uses standard RimWorld XML scribing (`HashSet<int>`); can be safely added to or removed from existing save files.

---

## 📋 Requirements

* **RimWorld:** `1.6` or `1.7` (.NET 10)
* **Harmony** (`brrainz.harmony`)

---

## 📦 Installation

### As Standalone Mod:
1. Place the `WorkManager` directory into your RimWorld `Mods/` folder:
   `RimWorld/Mods/WorkManager`
2. In the RimWorld Mod Manager, place **Harmony** at the top, then activate **SadSeal's Work Manager**.

### As Part of SadSeal's Mega Mod:
* This module is also included in **SadSeal's Mega Mod** under the **Work Manager** (`İş Yöneticisi`) tab in Mod Settings.

---

## 📜 License & Disclaimer

- Original design, assets, and concepts © **LordKuper**.
- Code adaptation and 1.7 port licensed under the [MIT License](LICENSE).
- This is a non-commercial, community-maintained compatibility update.
