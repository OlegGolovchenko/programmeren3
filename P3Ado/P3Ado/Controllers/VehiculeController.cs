using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P3AdoDA;

namespace P3Ado.Controllers
{
    public class VehiculeController : Controller
    {
        // GET: Vehicule
        public ActionResult Index()
        {
            List<Models.Vehicule> vehicules = DAVehicule.GetAllVehicules();
            return View(vehicules);
        }

        // GET: Vehicule/Details/5
        public ActionResult Details(int Dbid)
        {
            return View(DAVehicule.GetVehiculeById(Dbid));
        }

        public ActionResult EngineDetails(string name)
        {
            return PartialView(DAEngine.GetEngineByName(name));
        }

        // GET: Vehicule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicule/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.Vehicule vehiculeToSave = new Models.Vehicule();
                vehiculeToSave.Vin = collection["Vin"];
                vehiculeToSave.Make = collection["Make"];
                vehiculeToSave.Model = collection["Model"];
                vehiculeToSave.Ename = collection["Ename"];
                DAVehicule.CreateVehicule(vehiculeToSave);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicule/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DAVehicule.GetVehiculeById(id));
        }

        // POST: Vehicule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DAVehicule.UpdateVehicule(new Models.Vehicule() { Dbid = id, Vin = collection["Vin"], Make = collection["Make"], Model = collection["Model"], Ename = collection["Ename"] });
                return RedirectToAction("Edit",new { id=id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicule/Delete/5
        public ActionResult Delete(int id)
        {
            return View(DAVehicule.GetVehiculeById(id));
        }

        // POST: Vehicule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DAVehicule.DeleteVehicule(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
