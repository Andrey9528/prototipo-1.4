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
    public class registroIncapacidadController : Controller
    {
        private BD_RRHH2Entities1 db = new BD_RRHH2Entities1();

        // GET: registroIncapacidad
        public ActionResult Index()
        {
            var tbl_registroIncapacidad = db.tbl_registroIncapacidad.Include(t => t.tbl_empleado);
            return View(tbl_registroIncapacidad.ToList());
        }

        // GET: registroIncapacidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registroIncapacidad tbl_registroIncapacidad = db.tbl_registroIncapacidad.Find(id);
            if (tbl_registroIncapacidad == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registroIncapacidad);
        }

        // GET: registroIncapacidad/Create
        public ActionResult Create()
        {
            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre");
            return View();
        }

        // POST: registroIncapacidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_incapacidad,Id_empleado,Cantidad_dias,Tipo_incapacidad,Descripcion,Fecha_emision,Centro_emisor,Nombre_doc,Estado")] tbl_registroIncapacidad tbl_registroIncapacidad)
        {
            if (ModelState.IsValid)
            {
                db.tbl_registroIncapacidad.Add(tbl_registroIncapacidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre", tbl_registroIncapacidad.Id_empleado);
            return View(tbl_registroIncapacidad);
        }

        // GET: registroIncapacidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registroIncapacidad tbl_registroIncapacidad = db.tbl_registroIncapacidad.Find(id);
            if (tbl_registroIncapacidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre", tbl_registroIncapacidad.Id_empleado);
            return View(tbl_registroIncapacidad);
        }

        // POST: registroIncapacidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_incapacidad,Id_empleado,Cantidad_dias,Tipo_incapacidad,Descripcion,Fecha_emision,Centro_emisor,Nombre_doc,Estado")] tbl_registroIncapacidad tbl_registroIncapacidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_registroIncapacidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre", tbl_registroIncapacidad.Id_empleado);
            return View(tbl_registroIncapacidad);
        }

        // GET: registroIncapacidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registroIncapacidad tbl_registroIncapacidad = db.tbl_registroIncapacidad.Find(id);
            if (tbl_registroIncapacidad == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registroIncapacidad);
        }

        // POST: registroIncapacidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_registroIncapacidad tbl_registroIncapacidad = db.tbl_registroIncapacidad.Find(id);
            db.tbl_registroIncapacidad.Remove(tbl_registroIncapacidad);
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
