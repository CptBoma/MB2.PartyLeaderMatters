namespace PartyLeaderRoleXP
{
    internal static class Config
    {
        internal static float XPPercentage { get; set; } = 0.15f;
        internal static bool LeaderGainsScoutingXP { get; set; } = true;
        internal static bool LeaderGainsEngineeringXP { get; set; } = true;
        internal static bool LeaderGainsMedicineXP { get; set; } = true;
        internal static bool LeaderGainsStewardXP { get; set; } = true;

        internal static void CopyFromSettings(Settings settings)
        {
            XPPercentage = settings.XPPercentage;
            LeaderGainsScoutingXP = settings.LeaderGainsScoutingXP;
            LeaderGainsEngineeringXP = settings.LeaderGainsEngineeringXP;
            LeaderGainsMedicineXP = settings.LeaderGainsMedicineXP;
            LeaderGainsStewardXP = settings.LeaderGainsStewardXP;
        }
    }
}
