using System;
using LoadShedding.NET.REST;
namespace LoadShedding.NET
{
    public class LoadSheddingApi : HTTPClient
    {
        public LoadSheddingStatus IsLoadShedding() {
            string response = Get("/GetStatus");
            int status = Convert.ToInt32(response);
            if (status > 2) {
                return LoadSheddingStatus.IsLoadShedding;
            } else {
                return LoadSheddingStatus.None;
            }
        }

        public LoadSheddingStage GetLoadSheddingStage() {
            string response = Get("/GetStatus");
            int stage = Convert.ToInt32(response);
            return (LoadSheddingStage)(stage);
        }
    }
}
