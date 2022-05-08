using TestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestApiApp.Services
{
    public class RequestManager
    {
        IRestService restServ;
        public RequestManager(IRestService serv)
        {
            restServ = serv;
        }
        public Task<List<EntryModel>> GetEntrieModels()
        {
            return restServ.GetDataAsync();
        }
    }
}
