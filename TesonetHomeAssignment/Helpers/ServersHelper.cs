using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TesonetHomeAssignment.DB;
using TesonetHomeAssignment.DB.Models;

namespace TesonetHomeAssignment.Helpers
{
    static class ServersHelper
    {
        public static async Task<IEnumerable<Servers>> GetServersListFromApi(HttpClient client)
        {                      
            var response = await client.GetAsync("https://playground.tesonet.lt/v1/servers");
            var convertedResponse = await response.Content.ReadAsAsync<IEnumerable<Servers>>(new[] { new JsonMediaTypeFormatter() });
           
            return convertedResponse;
        }

        public static List<Servers> GetServersListFromDB()
        {
            var unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
            var servers = unitOfWork.Servers.GetAll().ToList();

            return servers;                               
        }

    }
}
