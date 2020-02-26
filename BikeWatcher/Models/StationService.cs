using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BikeWatcher.Models
{
    public class StationService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Stations>> FindStations()
        {
            // Connection à l'API
            var streamTask = client.GetStreamAsync("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");

            // déserialisation du json en objet
            var RetourAPI = await JsonSerializer.DeserializeAsync<RootObject>(await streamTask);


            var ListeStations = RetourAPI.values;

            return ListeStations;
        }
        public static async Task<List<StationBdx>> StationBdx()
        {
            var ApiData = client.GetStreamAsync("https://api.alexandredubois.com/vcub-backend/vcub.php");
            var RootObject = await JsonSerializer.DeserializeAsync<List<StationBdx>>(await ApiData);

            return RootObject;
        }
    }
}
