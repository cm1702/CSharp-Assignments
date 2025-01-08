using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using WebAPIAssessment.Models;

namespace WebAPIAssessment.Controllers
{
    public class CountryController : ApiController
    {
        private static CountryRepo _repository = new CountryRepo();

        [System.Web.Http.HttpGet]
        public IEnumerable<Country> Get()
        {
            return _repository.GetAllCountries();
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var country = _repository.GetCountry(id);
            if (country == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody] Country country)
        {
            if (country == null || string.IsNullOrWhiteSpace(country.CountryName) || string.IsNullOrWhiteSpace(country.Capital))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _repository.AddCountry(country);
            return Request.CreateResponse(HttpStatusCode.Created, country);
        }

        [System.Web.Http.HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Country country)
        {
            if (country == null || id != country.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _repository.UpdateCountry(country);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _repository.DeleteCountry(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}