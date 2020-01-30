using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeoUK;
using GeoUK.Coordinates;
using GeoUK.Projections;
using GeoUK.Ellipsoids;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static LatitudeLongitude ConvertEastNorthToLatLong(double easting, double northing)
        {
            // Convert to Cartesian
            var cartesian = GeoUK.Convert.ToCartesian(new Airy1830(),
                    new BritishNationalGrid(),
                    new EastingNorthing(easting, northing));
            //ETRS89 is effectively WGS84   
            var wgsCartesian = Transform.Osgb36ToEtrs89(cartesian);
            var wgsLatLong = GeoUK.Convert.ToLatitudeLongitude(new Wgs84(), wgsCartesian);
            return wgsLatLong;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            const double easting = 505118.45;
            const double northing = 185241.15;
            var result = ConvertEastNorthToLatLong(easting, northing);
            var resulta = result.Latitude;
            var resultb = result.Longitude;
            return new string[] { resulta.ToString(), resultb.ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
