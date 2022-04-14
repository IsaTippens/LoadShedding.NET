using LoadShedding.NET.Internal;
namespace LoadShedding.NET
{
    public class LoadSheddingClient : HTTPClient
    {
        public LoadSheddingClient() : base("https://loadshedding.eskom.co.za/LoadShedding")
        {

        }

        public async Task<LoadSheddingStage> GetLoadSheddingStage()
        {
            HttpResponseMessage response = await Get("/GetStatus");
            if (response.IsSuccessStatusCode)
            {
                string contents = await response.Content.ReadAsStringAsync();
                if (Int32.TryParse(contents, out int result))
                {
                    return (LoadSheddingStage)result;
                }
            }
            return LoadSheddingStage.Unknown;
        }

        public async Task<LoadSheddingStatus> GetLoadSheddingStatus()
        {
            LoadSheddingStage stage = await GetLoadSheddingStage();
            if (stage == LoadSheddingStage.Unknown)
            {
                return LoadSheddingStatus.Unknown;
            }
            if (stage == LoadSheddingStage.None)
            {
                return LoadSheddingStatus.None;
            }
            return LoadSheddingStatus.IsLoadShedding;
        }

        public async Task<bool> IsLoadShedding()
        {
            LoadSheddingStatus status = await GetLoadSheddingStatus();
            return status == LoadSheddingStatus.IsLoadShedding;
        }

    }
}
