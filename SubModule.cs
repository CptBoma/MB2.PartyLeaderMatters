using HarmonyLib;
using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace PartyLeaderRoleXP
{
    public class SubModule : MBSubModuleBase
    {
        private static Harmony harmony = null;

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            if (harmony == null)
            {
                try
                {
                    harmony = new Harmony("mod.bannerlord.PartyLeaderRoleXP");
                    harmony.PatchAll();
                }
                catch (Exception ex)
                {
                    InformationManager.DisplayMessage(new InformationMessage($"Error Initialising Role XP for Party Leader: {ex.Message}", TaleWorlds.Library.Color.Black));
                }
            }
        }
    }
}