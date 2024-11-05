// This code is auto generated!

namespace AStar.SettingsProviders
{
    internal sealed class AStarSettingsSampleSettingsProvider : AStar.Settings.SettingsProviderBase<AStarSettingsSampleSettingsProvider, AStar.Settings.Samples.Runtime.AStarSettingsSampleSettings>
    {
        [UnityEditor.SettingsProvider]
        public static UnityEditor.SettingsProvider CreateProvider() => CreateProviderInternal();

        protected override AStar.Settings.Samples.Runtime.AStarSettingsSampleSettings GetInstance() => AStar.Settings.Samples.Runtime.AStarSettingsSampleSettings.Instance;
    }
}