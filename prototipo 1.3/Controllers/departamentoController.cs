using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prototipo_1._3.BD.RRHH;

namespace prototipo_1._3.Controllers
{
    public class departamentoController : Controller
    {
        private BD_RRHH2Entities1 db = new BD_RRHH2Entities1();

        // GET: departamento
        public ActionResult Index()
        {
            return View(db.tbl_departamento.ToList());
        }

        // GET: departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_departamento tbl_departamento = db.tbl_departamento.Find(id);
            if (tbl_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_departamento);
        }

        // GET: departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: departamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_departamento,Nombre,Descripcion_d")] tbl_departamento tbl_departamento)
        {
            if (ModelState.IsValid)
            {
                db.tbl_departamento.Add(tbl_departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_departamento);
        }

        // GET: departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_departamento tbl_departamento = db.tbl_departamento.Find(id);
            if (tbl_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_departamento);
        }

        // POST: departamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_departamento,Nombre,Descripcion_d")] tbl_departamento tbl_departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_departamento);
        }

        // GET: departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_departamento tbl_departamento = db.tbl_departamento.Find(id);
            if (tbl_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_departamento);
        }

        // POST: departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_departamento tbl_departamento = db.tbl_departamento.Find(id);
            db.tbl_departamento.Remove(tbl_departamento);
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
