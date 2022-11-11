using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //GET: Car/List
        public ActionResult List()
        {
            using (var database = new WebApplication1DbContext())
            {
                //Get cars from database
                var cars = database.Cars
                    .Include(a => a.Author)
                    .ToList();

                return View(cars);
            }
        }
        //GET: Car/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var database = new WebApplication1DbContext())
            {
                //Get the car from database

                var car = database.Cars
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

            if (car == null)
                {
                    return HttpNotFound();
                }

                return View(car);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}