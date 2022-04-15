using LoadShedding.NET.Objects;
using LoadShedding.NET.Clients;
namespace LoadShedding.NET
{
    public class LoadSheddingClient : ILoadSheddingClient
    {
        ILoadSheddingClient _client;

        public LoadSheddingClient()
        {
            _client = new EskomLoadSheddingClient();
        }

        public LoadSheddingClient(ILoadSheddingClient client)
        {
            _client = client;
        }


        public async Task<LoadSheddingStage> GetLoadSheddingStage()
        {
            return await _client.GetLoadSheddingStage();
        }

        public async Task<LoadSheddingStatus> GetLoadSheddingStatus()
        {
            return await _client.GetLoadSheddingStatus();
        }

        public async Task<bool> IsLoadShedding()
        {
            return await _client.IsLoadShedding();
        }

        public async Task<string> GetMunicipalitiesData(Provinces province)
        {
            return await _client.GetMunicipalitiesData(province);
        }

        public async Task<List<Municipality>?> GetMunicipalities(Provinces province)
        {
            return await _client.GetMunicipalities(province);
        }

        public async Task<string> GetSuburbsData(Municipality municipality)
        {
            return await _client.GetSuburbsData(municipality);
        }

        public async Task<List<Suburb>?> GetSuburbs(Municipality municipality)
        {
            return await _client.GetSuburbs(municipality);
        }

        public async Task<string> GetScheduleData(Suburb suburb, LoadSheddingStage stage, Provinces province)
        {
            return await _client.GetScheduleData(suburb, stage, province);
        }

        public async Task<string> GetScheduleData(int suburb, int stage, int province)
        {
            return await _client.GetScheduleData(suburb, stage, province);
        }
    }
}
