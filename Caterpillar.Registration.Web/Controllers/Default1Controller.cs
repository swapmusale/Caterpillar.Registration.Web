using Caterpillar.Registration.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Caterpillar.Registration.Web.Controllers
{
    public class Default1Controller : Controller
    {
        // GET: Default1
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync("http://caterpillarregistrationapi.azurewebsites.net/api/application");
            var jsonstring = data.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(jsonstring))
            {
                //  jsonstring.Replace(@"\", string.Empty);
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<ApplicationRequestModel>>(jsonstring);
                return View(model);
            }
            return View();
        }

        // GET: Default1/Details/5
        public async Task<ActionResult> Details(string id)
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync(string.Format("http://caterpillarregistrationapi.azurewebsites.net/api/application/{0}", id));
            var jsonstring = data.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(jsonstring))
            {
                //  jsonstring.Replace(@"\", string.Empty);
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationRequestModel>(jsonstring);
                return View(model);
            }
            return View();
        }

        // GET: Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default1/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                var model = new ApplicationRequestModel()
                {
                    ApplicationId = Convert.ToInt32(collection["ApplicationId"]),
                    ApplicationName = collection["ApplicationName"],
                    AdminEmail = collection["AdminEmail"],
                    Description = collection["Description"],
                    IsActive = "true",
                    SourceEmail = collection["SourceEmail"]
                };
                var myContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(myContent);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");                
                var data = await client.PostAsync("http://caterpillarregistrationapi.azurewebsites.net/api/application", content);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default1/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync(string.Format("http://caterpillarregistrationapi.azurewebsites.net/api/application/{0}", id));
            var jsonstring = data.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(jsonstring))
            {
                //  jsonstring.Replace(@"\", string.Empty);
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationRequestModel>(jsonstring);
                return View(model);
            }
            return View();
        }

        // POST: Default1/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                var model = new ApplicationRequestModel()
                {
                    //ApplicationId = Convert.ToInt32(collection["ApplicationId"]),
                    ApplicationName = collection["ApplicationName"],
                    AdminEmail = collection["AdminEmail"],
                    Description = collection["Description"],
                    IsActive = "true",
                    SourceEmail = collection["SourceEmail"]
                };
                var myContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(myContent);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var data = await client.PutAsync("http://caterpillarregistrationapi.azurewebsites.net/api/application", content);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default1/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync(string.Format("http://caterpillarregistrationapi.azurewebsites.net/api/application/{0}", id));
            var jsonstring = data.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(jsonstring))
            {
                //  jsonstring.Replace(@"\", string.Empty);
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationRequestModel>(jsonstring);
                return View(model);
            }
            return View();
        }

        // POST: Default1/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                var data = await client.DeleteAsync(string.Format("http://caterpillarregistrationapi.azurewebsites.net/api/application/{0}", id));


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
