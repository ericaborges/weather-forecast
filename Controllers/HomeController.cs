using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WeatherForecast.Controllers
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

        public ActionResult GetData()
        {
            string baseUrl = "http://api.openweathermap.org/data/2.5/forecast?id=5894171&APPID=d8bab1626480bb4ce63248ad98bdf541";

            // Prepare the Request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl);

            // Set method to GET to retrieve data
            request.Method = "GET";
            request.Timeout = 60000; //60 second timeout
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows Phone OS 7.5; Trident/5.0; IEMobile/9.0)";

            string responseContent = null;
            //get date from now
            var dateNow = DateTime.Now.ToShortDateString();

            // Get the Response
            using (WebResponse response = request.GetResponse())
            {
                // Retrieve a handle to the Stream
                using (Stream stream = response.GetResponseStream())
                {
                    // Begin reading the Stream
                    using (StreamReader streamreader = new StreamReader(stream))
                    {
                        // Read the Response Stream to the end
                        responseContent = streamreader.ReadToEnd();
                    }

                    // serialize JSON directly to a file
                    using (StreamWriter file = System.IO.File.CreateText(@"D:\forecast_" + dateNow + ".json"))
                    {
                        file.Write(responseContent);
                    }
                }
            }

            ViewBag.Message = "File saved succesfully in: " + @"D:\forecast_" + dateNow + ".json";

            return View();
        }
    }
}