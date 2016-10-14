using P3AdoDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P3Ado.Controllers
{
    public class EngineController : Controller
    {
        // GET: Engine
        public ActionResult Index()
        {
            return View(DAEngine.GetAllEngines());
        }

        // GET: Engine/Details/5
        public ActionResult Details(int id)
        {
            return View(DAEngine.GetEngineById(id));
        }

        // GET: Engine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engine/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.Engine engine = new Models.Engine();
                int dbid;
                int.TryParse(collection["Dbid"], out dbid);
                engine.DbId = dbid;
                int disp;
                int.TryParse(collection["Displacement"], out disp);
                engine.Displacement = disp;
                int nbc;
                int.TryParse(collection["CylinderCount"], out nbc);
                engine.CylinderCount = nbc;
                engine.Name = collection["Name"];
                engine.Make = collection["Make"];
                DAEngine.CreateEngine(engine);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Engine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Engine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int disp;
                int.TryParse(collection["Displacement"], out disp);
                int nbc;
                int.TryParse(collection["CylinderCount"], out nbc);
                DAEngine.UpdateEngine(new Models.Engine() { DbId = id, Displacement = disp, CylinderCount = nbc, Name = collection["Name"], Make = collection["Make"] });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Engine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Engine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DAEngine.DeleteEngine(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
