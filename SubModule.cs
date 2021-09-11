using HarmonyLib;
using System;
using System.ComponentModel;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace PartyLeaderRoleXP
{
    public class SubModule : MBSubModuleBase
    {
        public static string Version => "1.1.0";
        public static string Name => typeof(SubModule).Namespace;

        private static Harmony harmony = null;
        public static string DisplayName => "Party Leader Role XP";

        internal static readonly Color ImportantTextColor = Color.FromUint(0x00F16D26); // orange

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (hasLoaded)
                return;
            try
            {
                var settings = Settings.Instance;
                if (settings != null)
                {
                    Config.CopyFromSettings(settings);
                    settings.PropertyChanged += Settings_OnPropertyChanged;
                }
                    
                harmony = new Harmony("mod.bannerlord.PartyLeaderRoleXP");
                harmony.PatchAll();
                InformationManager.DisplayMessage(new InformationMessage($"Loaded {DisplayName}", ImportantTextColor));
                hasLoaded = true;
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage($"Error Initialising Role XP for Party Leader: {ex.Message}", Color.Black));
            }
        }

        protected static void Settings_OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (sender is Settings settings && args.PropertyName == Settings.SaveTriggered)
            {
                Config.CopyFromSettings(settings);
            }
        }

        private bool hasLoaded;
    }
}