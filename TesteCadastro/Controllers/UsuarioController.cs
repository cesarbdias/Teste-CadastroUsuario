using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteCadastro.Models;

namespace TesteCadastro.Controllers
{
    public class UsuarioController : Controller
    {
        private CadastroUsuarioContext db = new CadastroUsuarioContext();


        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.DetalheUsuario);
            return View(usuario.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModels usuarioViewModels = db.Usuario.Find(id);
            if (usuarioViewModels == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModels);
        }

        public ActionResult Create()
        {
            ViewBag.IdDetalheUsuario = new SelectList(db.DetalheUsario, "IdDetalheUsuario", "Telefone");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModels usuarioViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuarioViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioViewModels);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModels usuarioViewModels = db.Usuario.Where(u => u.Id == id).Include(a => a.DetalheUsuario).First();
            if (usuarioViewModels == null)
            {
                return HttpNotFound();
            }

            return View(usuarioViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModels usuarioViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioViewModels);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModels usuarioViewModels = db.Usuario.Where(u => u.Id == id).Include(a => a.DetalheUsuario).First();
            if (usuarioViewModels == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioViewModels usuarioViewModels = db.Usuario.Where(u => u.Id == id).Include(a => a.DetalheUsuario).First();

            db.DetalheUsario.Remove(usuarioViewModels.DetalheUsuario);
            db.Usuario.Remove(usuarioViewModels);           
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
