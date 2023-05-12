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
    public class QuizsController : Controller
    {
        private QuizExamen0Entities2 db = new QuizExamen0Entities2();

        // GET: Quizs
        public async Task<ActionResult> PassQuiz()
        {
            return View();
        }
        public async Task<ActionResult> Revise()
        {
            return View();
        }

        public async Task<ActionResult> AnswerQuiz(int quizId)
        {
            //return questions
            var quiz = db.Quizs.Where(x=>x.quizID == quizId).FirstOrDefault<Quiz>();
            return View(quiz);
        }

        public async Task<ActionResult> ListQuiz(string userName, string email)
        {
            // get quiz list
            var quizes = await db.Quizs.Where<Quiz>(x => x.email == email && x.userName == userName).ToListAsync<Quiz>();
            return View(quizes);
        }

        // GET: Quizs
        public async Task<ActionResult> Index()
        {
            return View(await db.Quizs.ToListAsync());
        }

        // GET: Quizs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = await db.Quizs.FindAsync(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "quizID,userName,email,easyQuestionsNumber,mediumQuestionsNumber,hardQuestionsNumber")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                //1. add easy question to current quiz
                //var q = db.Questions.Where(x => x.Category.description == "easy")
                //    .Take(quiz.easyQuestionsNumber).ToList();
                quiz.Questions = quiz.Questions.Concat(
                    db.Questions.Where(x=>x.Category.description == "easy")
                    .Take(quiz.easyQuestionsNumber).ToList().AsEnumerable<Question>()
                    ).ToList();

                //2. add midium question to current quiz
                quiz.Questions = quiz.Questions.Concat(
                    db.Questions.Where(x => x.Category.description == "medium")
                    .Take(quiz.mediumQuestionsNumber).AsEnumerable<Question>()
                    ).ToList();
                //3. add hard question to current quiz
                quiz.Questions = quiz.Questions.Concat(
                    db.Questions.Where(x => x.Category.description == "hard")
                    .Take(quiz.hardQuestionsNumber).AsEnumerable<Question>()
                    ).ToList();

                db.Quizs.Add(quiz);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(quiz);
        }

        // GET: Quizs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = await db.Quizs.FindAsync(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "quizID,userName,email")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = await db.Quizs.FindAsync(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Quiz quiz = await db.Quizs.FindAsync(id);
            db.Quizs.Remove(quiz);
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
