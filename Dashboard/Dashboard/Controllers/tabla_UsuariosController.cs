using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dashboard;

namespace Dashboard.Controllers
{
    public class tabla_UsuariosController : Controller
    {
        private FullEntities db = new FullEntities();

        // GET: tabla_Usuarios
        public ActionResult Index()
        {
            return View(db.tabla_Usuarios.ToList());
        }

        // GET: tabla_Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabla_Usuarios tabla_Usuarios = db.tabla_Usuarios.Find(id);
            if (tabla_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Usuarios);
        }

        // GET: tabla_Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tabla_Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombres,Apellidos")] tabla_Usuarios tabla_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.tabla_Usuarios.Add(tabla_Usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabla_Usuarios);
        }

        // GET: tabla_Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabla_Usuarios tabla_Usuarios = db.tabla_Usuarios.Find(id);
            if (tabla_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Usuarios);
        }

        // POST: tabla_Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombres,Apellidos")] tabla_Usuarios tabla_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabla_Usuarios);
        }

        // GET: tabla_Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabla_Usuarios tabla_Usuarios = db.tabla_Usuarios.Find(id);
            if (tabla_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Usuarios);
        }

        // POST: tabla_Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tabla_Usuarios tabla_Usuarios = db.tabla_Usuarios.Find(id);
            db.tabla_Usuarios.Remove(tabla_Usuarios);
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
