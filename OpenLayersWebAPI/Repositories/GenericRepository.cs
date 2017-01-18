using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OpenLayersWebAPI.Models;
using System.Data.Entity.Core.Objects;

namespace OpenLayersWebAPI.Repositories
{
    class OpenLayerRepository : IRepository<GetSpatialData_Result> 
    {
        private Entities entities = null;
        

        public OpenLayerRepository(Entities _entities)
        {
            entities = _entities;            
        }

        public IEnumerable<GetSpatialData_Result> GetData(string query, params object[] parameters)
        {
            return entities.Database.SqlQuery<GetSpatialData_Result>(query, parameters);
        } 
    }
}