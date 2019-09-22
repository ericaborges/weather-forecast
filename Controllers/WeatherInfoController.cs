using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class WeatherInfoController : Controller
    {
        private WeatherInfoContext db = new WeatherInfoContext();

        // GET: WeatherInfo
        public ActionResult Index(int? page)
        {
            //get list from the database
            var list = db.Weather_info.ToList();
            foreach (var item in list)
            {
                //kelvin to celsius
                item.main_temp -= (decimal)273.15; 
                item.main_temp_max -= (decimal)273.15;
                item.main_temp_min -= (decimal)273.15;
            }
            //initialize pager with list count
            var pager = new Pager(list.Count(), page);

            //initialize model with the list and the pager to transfer to view.
            var viewModel = new IndexViewModel
            {
                Items = list.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }

        // GET: WeatherInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weather_info weather_info = db.Weather_info.Find(id);
            
            if (weather_info == null)
            {
                return HttpNotFound();
            }

            //kelvin to celsius
            weather_info.main_temp -= (decimal)273.15;
            weather_info.main_temp_max -= (decimal)273.15;
            weather_info.main_temp_min -= (decimal)273.15;

            return View(weather_info);
        }

        // GET: WeatherInfo/Create
        public ActionResult Create()
        {
            //get today's date
            var date = DateTime.UtcNow;

            //creates a UNIX timestamp to match the Primary Key on the table
            var unixTimestamp = (date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var model = new Weather_info()
            {
                dt = (int)unixTimestamp,
                dt_txt = date.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return View(model);
        }

        // POST request: WeatherInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Weather_info weather_info)
        {
            /* we insert default values here due to not know what they mean
             maybe they are related to other systems in the original API website */

            weather_info.weather_icon = "";
            weather_info.syspod = "";

            //celsius to kelvin (keep pattern in database)
            weather_info.main_temp += (decimal)273.15;
            weather_info.main_temp_max += (decimal)273.15;
            weather_info.main_temp_min += (decimal)273.15;

            if (ModelState.IsValid)
            {
                db.Weather_info.Add(weather_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weather_info);
        }

        // GET: WeatherInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weather_info weather_info = db.Weather_info.Find(id);

            if (weather_info == null)
            {
                return HttpNotFound();
            }

            //kelvin to celsius
            weather_info.main_temp -= (decimal)273.15;
            weather_info.main_temp_max -= (decimal)273.15;
            weather_info.main_temp_min -= (decimal)273.15;

            return View(weather_info);
        }

        // POST: WeatherInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dt,main_temp,main_temp_min,main_temp_max,main_pressure,main_sea_level,main_grnd_level,main_humidity,main_temp_kf,weather_id,weather_main,weather_description,weather_icon,clouds_all,wind_speed,wind_deg,syspod,dt_txt,snow_3h,rain_3h")] Weather_info weather_info)
        {
            if (ModelState.IsValid)
            {
                weather_info.weather_icon = "";
                weather_info.syspod = "";
                //celsius to kelvin (keep pattern in database)
                weather_info.main_temp += (decimal)273.15;
                weather_info.main_temp_max += (decimal)273.15;
                weather_info.main_temp_min += (decimal)273.15;

                db.Entry(weather_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weather_info);
        }

        // GET: WeatherInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weather_info weather_info = db.Weather_info.Find(id);
            if (weather_info == null)
            {
                return HttpNotFound();
            }

            //kelvin to celsius
            weather_info.main_temp -= (decimal)273.15;
            weather_info.main_temp_max -= (decimal)273.15;
            weather_info.main_temp_min -= (decimal)273.15;

            return View(weather_info);
        }

        // POST: WeatherInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weather_info weather_info = db.Weather_info.Find(id);
            db.Weather_info.Remove(weather_info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    public class IndexViewModel
    {
        public IEnumerable<Weather_info> Items { get; set; }
        public Pager Pager { get; set; }
    }
}
