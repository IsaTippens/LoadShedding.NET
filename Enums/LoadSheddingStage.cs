using System.ComponentModel;
namespace LoadShedding.NET
{
    public enum LoadSheddingStage
    {
        [Description("Unknown")]
        Unknown,
        [Description("None")]
        None,
        [Description("Stage 1")]
        Stage1,
        [Description("Stage 2")]
        Stage2,
        [Description("Stage 3")]
        Stage3,
        [Description("Stage 4")]
        Stage4,
        [Description("Stage 5")]
        Stage5,
        [Description("Stage 6")]
        Stage6,
        [Description("Stage 7")]
        Stage7,
        [Description("Stage 8")]
        Stage8
    }

    public static class LoadSheddingStageExtensions
    {
        public static string ToString(this LoadSheddingStage stage)
        {
            switch (stage)
            {
                case LoadSheddingStage.None:
                    return "None";
                case LoadSheddingStage.Stage1:
                    return "Stage 1";
                case LoadSheddingStage.Stage2:
                    return "Stage 2";
                case LoadSheddingStage.Stage3:
                    return "Stage 3";
                case LoadSheddingStage.Stage4:
                    return "Stage 4";
                case LoadSheddingStage.Stage5:
                    return "Stage 5";
                case LoadSheddingStage.Stage6:
                    return "Stage 6";
                case LoadSheddingStage.Stage7:
                    return "Stage 7";
                case LoadSheddingStage.Stage8:
                    return "Stage 8";
                default:
                    return "Unknown";
            }
        }
    }
}