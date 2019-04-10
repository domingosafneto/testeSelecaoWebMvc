using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contatos.Models;

namespace Contatos.Controllers
{
    public class ContatosController : Controller
    {
        private BancoContext db = new BancoContext();        

        // GET: Contatos
        public ActionResult Index()
        {
            var contatos = db.Contatos.Include(c => c.Pessoa);
            
            return View(contatos.ToList());
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            ViewBag.IdPessoa = new SelectList(db.Pessoas, "Id", "Nome");            
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPessoa,Valor,Tipo")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Contatos.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index", "Pessoas");
            }

            ViewBag.IdPessoa = new SelectList(db.Pessoas, "Id", "Nome", contato.IdPessoa);
            return View(contato);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPessoa = new SelectList(db.Pessoas, "Id", "Nome", contato.IdPessoa);            
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPessoa,Valor,Tipo")] Contato contato)
        {
            if (ModelState.IsValid)
            {               
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Pessoas");    // Action, Controller             
            }
            ViewBag.IdPessoa = new SelectList(db.Pessoas, "Id", "Nome", contato.IdPessoa);
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contato contato = db.Contatos.Find(id);
            db.Contatos.Remove(contato);
            db.SaveChanges();
            return RedirectToAction("Index", "Pessoas");
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
