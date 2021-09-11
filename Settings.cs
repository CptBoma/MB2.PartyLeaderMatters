using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

namespace PartyLeaderRoleXP
{
    public class Settings : AttributeGlobalSettings<Settings>
    {
        public override string Id => $"{SubModule.Name}_v1";
        public override string DisplayName => SubModule.DisplayName;

        private const string LeaderGainsScoutingXP_Hint = "Party Leader gains Scouting Role XP?" +
            " [ Default: true ] ";
        private const string LeaderGainsEngineeringXP_Hint = "Party Leader gains Engineering Role XP?" +
            " [ Default: true ] ";
        private const string LeaderGainsMedicineXP_Hint = "Party Leader gains Medicine Role XP?" +
            " [ Default: true ] ";
        private const string LeaderGainsStewardXP_Hint = "Party Leader gains Steward Role XP?" +
            " [ Default: true ] ";
        private const string XPPercentage_Hint = "Fraction of role XP to be given to Party Leader." +
            " [ Default: 0.15 (15%) ] " +
            " [ Min: 0.0; Max 10.0 ] ";

        [SettingPropertyBool("Scouting", HintText = LeaderGainsScoutingXP_Hint ,RequireRestart = false, Order = 0)]
        [SettingPropertyGroup("Enable Role XP")]
        public bool LeaderGainsScoutingXP { get; set; } = Config.LeaderGainsScoutingXP;

        [SettingPropertyBool("Engineering", HintText = LeaderGainsEngineeringXP_Hint, RequireRestart = false, Order = 1)]
        [SettingPropertyGroup("Enable Role XP")]
        public bool LeaderGainsEngineeringXP { get; set; } = Config.LeaderGainsEngineeringXP;

        [SettingPropertyBool("Medicine", HintText = LeaderGainsMedicineXP_Hint, RequireRestart = false, Order = 2)]
        [SettingPropertyGroup("Enable Role XP")]
        public bool LeaderGainsMedicineXP { get; set; } = Config.LeaderGainsMedicineXP;

        [SettingPropertyBool("Steward", HintText = LeaderGainsStewardXP_Hint, RequireRestart = false, Order = 3)]
        [SettingPropertyGroup("Enable Role XP")]
        public bool LeaderGainsStewardXP { get; set; } = Config.LeaderGainsStewardXP;

        [SettingPropertyFloatingInteger("XP Percentage", 0.0f, 10.0f, HintText = XPPercentage_Hint, RequireRestart = false, Order = 0)]
        [SettingPropertyGroup("XP Percentage")]
        public float XPPercentage { get; set; } = Config.XPPercentage;
    }
}
