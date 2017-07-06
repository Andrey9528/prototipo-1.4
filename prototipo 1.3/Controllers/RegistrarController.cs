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
    public class RegistrarController : Controller
    {
        private BD_RRHH2Entities1 db = new BD_RRHH2Entities1();

        // GET: Registrar
        public ActionResult Index()
        {
            var tbl_usuario = db.tbl_usuario.Include(t => t.tbl_empleado).Include(t => t.tbl_expediente).Include(t => t.tbl_roles);
            return View(tbl_usuario.ToList());
        }

        // GET: Registrar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // GET: Registrar/Create
        public ActionResult Create()
        {
            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre");
            ViewBag.Id_expediente = new SelectList(db.tbl_expediente, "Id_expediente", "Nivel_academico");
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto");
            return View();
        }

        // POST: Registrar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_usuario,Nombre,Password,Estado,Id_rol,Id_expediente,Id_empleado")] tbl_usuario tbl_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tbl_usuario.Add(tbl_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre", tbl_usuario.Id_empleado);
            ViewBag.Id_expediente = new SelectList(db.tbl_expediente, "Id_expediente", "Nivel_academico", tbl_usuario.Id_expediente);
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto", tbl_usuario.Id_rol);
            return View(tbl_usuario);
        }

        // GET: Registrar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre", tbl_usuario.Id_empleado);
            ViewBag.Id_expediente = new SelectList(db.tbl_expediente, "Id_expediente", "Nivel_academico", tbl_usuario.Id_expediente);
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto", tbl_usuario.Id_rol);
            return View(tbl_usuario);
        }

        // POST: Registrar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_usuario,Nombre,Password,Estado,Id_rol,Id_expediente,Id_empleado")] tbl_usuario tbl_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_empleado = new SelectList(db.tbl_empleado, "Id_empleado", "Nombre", tbl_usuario.Id_empleado);
            ViewBag.Id_expediente = new SelectList(db.tbl_expediente, "Id_expediente", "Nivel_academico", tbl_usuario.Id_expediente);
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto", tbl_usuario.Id_rol);
            return View(tbl_usuario);
        }

        // GET: Registrar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // POST: Registrar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            db.tbl_usuario.Remove(tbl_usuario);
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
