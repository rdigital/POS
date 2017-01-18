using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Types;

namespace OpenLayersWebAPI.ViewModels
{
    public class deliveryPoint
    {
        public int id { get; set; }
        public SqlGeometry spatial { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string postcode { get; set; }
        public string street_name { get; set; }
        public string type { get; set; }

    }
}