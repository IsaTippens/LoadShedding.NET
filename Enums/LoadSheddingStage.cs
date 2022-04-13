namespace LoadShedding.NET
{
    public enum LoadSheddingStage
    {
        Unknown,
        None,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Stage6,
        Stage7,
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