using LoadShedding.NET.Objects;
namespace LoadShedding.NET.Clients
{
    public interface ILoadSheddingClient
    {

        Task<LoadSheddingStage> GetLoadSheddingStage();

        Task<LoadSheddingStatus> GetLoadSheddingStatus();

        Task<bool> IsLoadShedding();

        Task<string> GetMunicipalitiesData(Provinces province);
        Task<List<Municipality>?> GetMunicipalities(Provinces province);

        Task<string> GetSuburbsData(Municipality municipality);

        Task<List<Suburb>?> GetSuburbs(Municipality municipality);

        Task<string> GetScheduleData(Suburb suburb, LoadSheddingStage stage, Provinces province);

        Task<string> GetScheduleData(int suburb, int stage, int province);

    }
}
