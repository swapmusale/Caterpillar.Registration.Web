using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterpillar.Registration.Web.Models
{
    //Application model
    public class ApplicationRequestModel
    {
        [JsonProperty("applicationid")]
        public long? ApplicationId { get; set; }

        [JsonProperty("applicationname")]
        public string ApplicationName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sourceemail")]
        public string SourceEmail { get; set; }

        [JsonProperty("adminEmail")]
        public string AdminEmail { get; set; }

        [JsonProperty("isactive")]
        public string IsActive { get; set; }
    }
}