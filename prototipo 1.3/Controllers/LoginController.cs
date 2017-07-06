using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prototipo_1._3.BD.RRHH;

namespace prototipo_1._3.Controllers
{
    public class LoginController : Controller
    {
        private BD_RRHH2Entities1 DB = new BD_RRHH2Entities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "Id_usuario,Nombre,Password,Estado,Id_rol,Id_expediente,Id_empleado")]tbl_usuario tbl_usuario)
        {
            var usr = DB.tbl_usuario.Where(y => y.Nombre == tbl_usuario.Nombre && y.Password == tbl_usuario.Password).FirstOrDefault();
            if (usr !=null )
            {
                Session["Id_usuario"] = usr.Id_usuario.ToString();
                Session["Nombre"] = usr.Nombre.ToString();
                return RedirectToAction("Bienvenido");
            }
            else
            {
                ModelState.AddModelError("","Usuario o password incorrecto");
            }
            return View();
            
        }
        public ActionResult Bienvenido ()
        {
            if (Session["Id_usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}