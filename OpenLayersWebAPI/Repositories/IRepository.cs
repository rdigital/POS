using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenLayersWebAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetData(string query, params object[] parameters);
    }
}