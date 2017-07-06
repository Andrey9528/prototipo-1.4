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
    public class EmpleadoController : Controller
    {
        private BD_RRHH2Entities1 db = new BD_RRHH2Entities1();

        // GET: Empleado
        public ActionResult Index()
        {
            var tbl_empleado = db.tbl_empleado.Include(t => t.tbl_departamento).Include(t => t.tbl_roles);
            return View(tbl_empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_empleado tbl_empleado = db.tbl_empleado.Find(id);
            if (tbl_empleado == null)
            {
                return HttpNotFound();
            }
            return View(tbl_empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Id_departamento = new SelectList(db.tbl_departamento, "Id_departamento", "Nombre");
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_empleado,Nombre,Primer_apellido,Segundo_apellido,Direccion,Telefono,Correo,Estado_civil,Fecha_naci,Id_departamento,Id_rol,Estado")] tbl_empleado tbl_empleado)
        {
            if (ModelState.IsValid)
            {
                db.tbl_empleado.Add(tbl_empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_departamento = new SelectList(db.tbl_departamento, "Id_departamento", "Nombre", tbl_empleado.Id_departamento);
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto", tbl_empleado.Id_rol);
            return View(tbl_empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_empleado tbl_empleado = db.tbl_empleado.Find(id);
            if (tbl_empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_departamento = new SelectList(db.tbl_departamento, "Id_departamento", "Nombre", tbl_empleado.Id_departamento);
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto", tbl_empleado.Id_rol);
            return View(tbl_empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_empleado,Nombre,Primer_apellido,Segundo_apellido,Direccion,Telefono,Correo,Estado_civil,Fecha_naci,Id_departamento,Id_rol,Estado")] tbl_empleado tbl_empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_departamento = new SelectList(db.tbl_departamento, "Id_departamento", "Nombre", tbl_empleado.Id_departamento);
            ViewBag.Id_rol = new SelectList(db.tbl_roles, "Id_rol", "Puesto", tbl_empleado.Id_rol);
            return View(tbl_empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_empleado tbl_empleado = db.tbl_empleado.Find(id);
            if (tbl_empleado == null)
            {
                return HttpNotFound();
            }
            return View(tbl_empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_empleado tbl_empleado = db.tbl_empleado.Find(id);
            db.tbl_empleado.Remove(tbl_empleado);
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
