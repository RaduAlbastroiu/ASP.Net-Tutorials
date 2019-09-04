using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
  public class EntriesController : ApiController
  {
    [HttpGet]
    public IEnumerable<Entry> Get()
    {
      var activityBiking = new Activity() { Name = "Biking" };
      return new List<Entry>()
      {
        new Entry(2017, 1, 2,activityBiking, 10.0m),
        new Entry(2017, 1, 2,activityBiking, 12.0m),
        new Entry(2017, 1, 2,activityBiking, 15.0m)
      };
    }

    public Entry Get(int id)
    {
      return null;
    }

    [HttpPost]
    public void Post()
    {

    }

    [HttpPut]
    public void Put()
    {

    }

    [HttpDelete]
    public void Delete()
    {

    }
  }
}