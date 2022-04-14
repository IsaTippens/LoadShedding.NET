using System.ComponentModel;

namespace LoadShedding.NET
{
    public enum LoadSheddingStatus
    {
        Unknown,
        None,
        [Description("Currently load shedding")]
        IsLoadShedding
    }

    static class LoadSheddingStatusExtensions
    {

        public static string ToString(this LoadSheddingStatus status)
        {
            switch (status)
            {
                case LoadSheddingStatus.None:
                    return "None";
                case LoadSheddingStatus.IsLoadShedding:
                    return "Is Load Shedding";
                default:
                    return "Unknown";
            }
        }
    }
}