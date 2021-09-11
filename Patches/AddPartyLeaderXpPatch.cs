using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace PartyLeaderRoleXP.Patches
{
    [HarmonyPatch(typeof(Hero), "AddSkillXp")]
    public class AddPartyLeaderXpPatch
    {
        private static FieldInfo hdFieldInfo = null;
        static void Postfix(Hero __instance, SkillObject skill, float xpAmount)
        {
            try
            {
                if (xpAmount > 0  && __instance.PartyBelongedTo != null && !__instance.IsPartyLeader)
                {
                    MobileParty party = __instance.PartyBelongedTo;
                    if (party.EffectiveScout == __instance && skill.Name.ToString() == "Scouting" && Config.LeaderGainsScoutingXP
                        || party.EffectiveEngineer == __instance && skill.Name.ToString() == "Engineering" && Config.LeaderGainsEngineeringXP
                        || party.EffectiveSurgeon == __instance && skill.Name.ToString() == "Medicine" && Config.LeaderGainsMedicineXP
                        || party.EffectiveQuartermaster == __instance && skill.Name.ToString() == "Steward" && Config.LeaderGainsStewardXP)
                    {
                        if (hdFieldInfo == null) GetFieldInfo();
                        Hero partyLeader = party.LeaderHero ?? null;
                        if (partyLeader != null)
                        {
                            HeroDeveloper plhd = (HeroDeveloper)hdFieldInfo.GetValue(partyLeader);
                            float newXpAmount = (float)(xpAmount * Config.XPPercentage);
                            plhd.AddSkillXp(skill, newXpAmount, true, true);
                            //InformationManager.DisplayMessage(new InformationMessage($"{skill.Name} Role xp: {xpAmount} Leader xp: {newXpAmount}. Percentage: {Config.XPPercentage}", TaleWorlds.Library.Color.Black));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage($"An exception occurred whilst trying to apply role xp to party leader: {ex}", TaleWorlds.Library.Color.Black));
            }
        }

        private static void GetFieldInfo()
        {
            hdFieldInfo = typeof(Hero).GetField("_heroDeveloper", BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}
