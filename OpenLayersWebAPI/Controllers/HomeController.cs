using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenLayersWebAPI.UnitOfWork;
using System.Data.SqlClient;
using System.Data;
using OpenLayersWebAPI.Models;
using Newtonsoft.Json;
using OpenLayersWebAPI.DataTypes;
using Newtonsoft.Json.Linq;
using Microsoft.SqlServer.Types;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using System.Text;
using System.IO;
using OpenLayersWebAPI.ActionFilters;

namespace OpenLayersWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [LogActionFilter]
        public ActionResult GetData(string bbox)
        {
            var bboxArr = bbox.Split(',').Select(c => double.Parse(c)).ToArray();
            GenericUnitOfWork gUoW = new GenericUnitOfWork();
            List<GetSpatialData_Result> result =  gUoW.DeliveryPointRepository.GetData("GetSpatialData @x1, @x2, @y1, @y2",
                new SqlParameter("@x1", SqlDbType.Decimal) { Value = bboxArr[0]},
                new SqlParameter("@x2", SqlDbType.Decimal) { Value = bboxArr[1]},
                new SqlParameter("@y1", SqlDbType.Decimal) { Value = bboxArr[2]},
                new SqlParameter("@y2", SqlDbType.Decimal) { Value = bboxArr[3]}).ToList<GetSpatialData_Result>();


            var geoJson = new GeoJson
            {
                features = new List<Feature>()
            };

            foreach (var point in result)
            {
                SqlGeometry sqlGeo = SqlGeometry.STGeomFromWKB(new SqlBytes(point.spatial.AsBinary()), 0);

                var feature = new Feature
                {
                    id = point.id,
                    properties = new Dictionary<string, JToken>
                    {
                        { "name", point.name },
                        { "number", point.number },
                        { "postcode", point.postcode },
                        { "street_name", point.street_name }
                    },
                    geometry = new Geometry
                    {

                        coordinates = new Coordinates(sqlGeo)
                    }
                };
                geoJson.features.Add(feature);
            }

            //string json = JsonConvert.SerializeObject(result,
            //                Newtonsoft.Json.Formatting.None,
            //                new JsonSerializerSettings
            //                {
            //                    NullValueHandling = NullValueHandling.Ignore
            //                });

            var resultBytes = Encoding.UTF8.GetBytes(geoJson.getJson().ToString());


            return new FileStreamResult(new MemoryStream(resultBytes), "application/json");


        }

    }
}