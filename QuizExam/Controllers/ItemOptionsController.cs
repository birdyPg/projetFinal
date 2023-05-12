using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizExam.Data;

namespace QuizExam.Controllers
{
    public class ItemOptionsController : Controller
    {
        private QuizExamen0Entities2 db = new QuizExamen0Entities2();

        // GET: ItemOptions
        public async Task<ActionResult> Index()
        {
            var itemOptions = db.ItemOptions.Include(i => i.Question);
            return View(await itemOptions.ToListAsync());
        }

        // GET: ItemOptions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOption itemOption = await db.ItemOptions.FindAsync(id);
            if (itemOption == null)
            {
                return HttpNotFound();
            }
            return View(itemOption);
        }

        // GET: ItemOptions/Create
        public ActionResult Create()
        {
            ViewBag.questionID = new SelectList(db.Questions, "questionID", "text");
            return View();
        }

        // POST: ItemOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "optionID,text,isRight,questionID")] ItemOption itemOption)
        {
            if (ModelState.IsValid)
            {
                db.ItemOptions.Add(itemOption);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.questionID = new SelectList(db.Questions, "questionID", "text", itemOption.questionID);
            return View(itemOption);
        }

        // GET: ItemOptions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOption itemOption = await db.ItemOptions.FindAsync(id);
            if (itemOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.questionID = new SelectList(db.Questions, "questionID", "text", itemOption.questionID);
            return View(itemOption);
        }

        // POST: ItemOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "optionID,text,isRight,questionID")] ItemOption itemOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemOption).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.questionID = new SelectList(db.Questions, "questionID", "text", itemOption.questionID);
            return View(itemOption);
        }

        // GET: ItemOptions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOption itemOption = await db.ItemOptions.FindAsync(id);
            if (itemOption == null)
            {
                return HttpNotFound();
            }
            return View(itemOption);
        }

        // POST: ItemOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemOption itemOption = await db.ItemOptions.FindAsync(id);
            db.ItemOptions.Remove(itemOption);
            await db.SaveChangesAsync();
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
