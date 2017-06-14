using Caterpillar.Registration.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Caterpillar.Registration.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync("http://caterpillarregistrationapi.azurewebsites.net/api/application");

            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationRequestModel>(data.Content.ReadAsStringAsync().Result);
            return View(model);
        }

        // GET: Default1/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}