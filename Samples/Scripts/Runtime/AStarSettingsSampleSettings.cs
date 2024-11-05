using System;

namespace AStar.Settings.Samples.Runtime
{
    [Serializable]
    public sealed class AStarSettingsSampleSettings : SettingsBase<AStarSettingsSampleSettings>, IEditOnProjectSettings
    {
        [Serializable]
        public class InnerClass
        {
            public float InnerString;
            public int InnerInt;
        }

        public string SampleString;
        public int SampleInt;
        public InnerClass Inner;
    }
}