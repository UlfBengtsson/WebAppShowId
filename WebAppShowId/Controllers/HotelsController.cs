using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppShowId.Models;

namespace WebAppShowId.Controllers
{
    public class HotelsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Hotels
        public ActionResult Index()
        {

            return View(db.Hotels.Include("Rooms"));
        }

        public ActionResult HotelListItem(int id)
        {
            Hotel hotel = db.Hotels.Include("Rooms").SingleOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return new HttpStatusCodeResult(400);
            }
            else
            {
                return PartialView("_HotelListItem", hotel);
            }
        }

        public ActionResult HotelDetails(int id)
        {
            Hotel hotel = db.Hotels.Include("Rooms").SingleOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return new HttpStatusCodeResult(400);
            }
            else
            {
                return PartialView("_HotelDetails", hotel);
            }
        }
    }
}