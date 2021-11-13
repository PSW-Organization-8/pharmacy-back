using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class RegisteredHospital
    {
        [Key]
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }

        public RegisteredHospital() { }

        public RegisteredHospital(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public RegisteredHospital(string name, string url, string apiKey)
        {
            this.Name = name;
            this.Url = url;
            this.ApiKey = apiKey;
        }
    }
}
