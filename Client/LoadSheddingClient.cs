using System.Text.Json;
using System.Text.Json.Serialization;
using LoadShedding.NET.Internal;
using System.Collections.Generic;
using LoadShedding.NET.Objects;
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
            switch (await GetLoadSheddingStage())
            {
                case LoadSheddingStage.Unknown:
                    return LoadSheddingStatus.Unknown;
                case LoadSheddingStage.None:
                    return LoadSheddingStatus.None;
                default:
                    return LoadSheddingStatus.IsLoadShedding;
            }
        }

        public async Task<bool> IsLoadShedding()
        {
            LoadSheddingStatus status = await GetLoadSheddingStatus();
            return status == LoadSheddingStatus.IsLoadShedding;
        }

        public async Task<string> GetMunicipalitiesData(Provinces province)
        {
            HttpResponseMessage response = await Get($"/GetMunicipalities/?Id={(int)province}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public async Task<List<Municipality>?> GetMunicipalities(Provinces province)
        {
            string json = await GetMunicipalitiesData(province);
            return JsonSerializer.Deserialize<List<Municipality>>(json);
        }

        public async Task<string> GetSuburbsData(Municipality municipality)
        {
            HttpResponseMessage response = await Get($"/GetSurburbData/?pageSize=100&pageNum=1&id={municipality.ID}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public async Task<List<Suburb>?> GetSuburbs(Municipality municipality)
        {
            string json = await GetSuburbsData(municipality);
            SuburbsData? data = JsonSerializer.Deserialize<SuburbsData>(json);
            return data?.Results;
        }

        public async Task<string> GetScheduleData(Suburb suburb, LoadSheddingStage stage, Provinces province)
        {
            return await GetScheduleData(int.Parse(suburb.ID!), (int)stage - 1, (int)province);
        }

        public async Task<string> GetScheduleData(int suburb, int stage, int province)
        {
            HttpResponseMessage response = await Get($"/GetScheduleM/{suburb}/{stage}/{province}/1");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

    }
}
