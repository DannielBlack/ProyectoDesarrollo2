using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class ActividadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Actividades
        public ActionResult Index()
        {
            var actividades = db.Actividades.Include(a => a.Personas);
            return View(actividades.ToList());
        }

        // GET: Actividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        //[Authorize(Roles = "Admin")]
        // GET: Actividades/Create
        public ActionResult Create()
        {
            ViewBag.PersonasID = new SelectList(db.Personas, "PersonasID", "Nombre");
            return View();
        }

        // POST: Actividades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActividadesID,PersonasID,Lugar,Descripcion,Fecha")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                db.Actividades.Add(actividades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonasID = new SelectList(db.Personas, "PersonasID", "Nombre", actividades.PersonasID);
            return View(actividades);
        }

        //[Authorize(Roles = "Admin")]
        // GET: Actividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonasID = new SelectList(db.Personas, "PersonasID", "Nombre", actividades.PersonasID);
            return View(actividades);
        }

        // POST: Actividades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActividadesID,PersonasID,Lugar,Descripcion,Fecha")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonasID = new SelectList(db.Personas, "PersonasID", "Nombre", actividades.PersonasID);
            return View(actividades);
        }

        //[Authorize(Roles = "Admin")]
        // GET: Actividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividades actividades = db.Actividades.Find(id);
            db.Actividades.Remove(actividades);
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
}
