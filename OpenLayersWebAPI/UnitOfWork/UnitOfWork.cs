using OpenLayersWebAPI.Models;
using OpenLayersWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenLayersWebAPI.UnitOfWork
{
    public class GenericUnitOfWork : IDisposable
    {
        private Entities entities = null;
        public GenericUnitOfWork()
        {
            entities = new Entities();
        }

        // Add all the repository handles here
        IRepository<GetSpatialData_Result> deliveryPointRepository = null;

        // Add all the repository getters here
        public IRepository<GetSpatialData_Result> DeliveryPointRepository
        {
            get
            {
                if (deliveryPointRepository == null)
                {
                    deliveryPointRepository = new  OpenLayerRepository(entities);
                }
                return deliveryPointRepository;
            }
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}