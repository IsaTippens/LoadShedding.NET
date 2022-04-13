using LoadShedding.NET.REST;
using System;
namespace LoadShedding.NET
{
    public class LoadSheddingClient : HTTPClient
    {
        public bool IsLoadShedding() {
            string response = Get("/GetStatus");
            Console.WriteLine(response);
            return false;
        }
    }
}
