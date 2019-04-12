using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BingoOnline.Cards;
using BingoOnline.Models;

namespace BingoOnline.Controllers
{
    public class BingosController : Controller
    {
        private DataContext dbContext = new DataContext();
        readonly int MAX_CARDS = 2;
        // GET: Bingos
        public ActionResult Index()
        {
            var bingos = dbContext.Bingos.Include(b => b.Award);
            return View(bingos.ToList());
        }

        // GET: Bingos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bingo bingo = dbContext.Bingos.Find(id);
            if (bingo == null)
            {
                return HttpNotFound();
            }
            return View(bingo);
        }

        // GET: Bingos/Create
        public ActionResult Create()
        {
            ViewBag.AwardsID = new SelectList(dbContext.Awards, "AwardsID", "Name");
            return View();
        }

        // POST: Bingos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BingoID,RaffleDate,RaffleHour,Status,Description,AwardsID")] Bingo bingo)
        {
            if (ModelState.IsValid)
            {
                dbContext.Bingos.Add(bingo);

                GenerateCard generateCard = new GenerateCard();
                Card card = new Card();
                for (int i = 0; i <= MAX_CARDS - 1; i++)
                {
                    card.CardValues = generateCard.CreateSortedNumbers();
                    card.CardHits = 0;
                    dbContext.Cards.Add(card);
                    dbContext.SaveChanges();
                }
        
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
            }

            ViewBag.AwardsID = new SelectList(dbContext.Awards, "AwardsID", "Name", bingo.AwardsID);
           
            return View(bingo);
        }

        // GET: Bingos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bingo bingo = dbContext.Bingos.Find(id);
            if (bingo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AwardsID = new SelectList(dbContext.Awards, "AwardsID", "Name", bingo.AwardsID);
            return View(bingo);
        }

        // POST: Bingos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BingoID,RaffleDate,RaffleHour,Status,Description,AwardsID")] Bingo bingo)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(bingo).State = EntityState.Modified;
            }
            ViewBag.AwardsID = new SelectList(dbContext.Awards, "AwardsID", "Name", bingo.AwardsID);
            return View(bingo);
        }

        // GET: Bingos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bingo bingo = dbContext.Bingos.Find(id);
            if (bingo == null)
            {
                return HttpNotFound();
            }
            return View(bingo);
        }

        // POST: Bingos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bingo bingo = dbContext.Bingos.Find(id);
            dbContext.Bingos.Remove(bingo);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Raffle([Bind(Include = "BingoID")] Bingo bingo)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(bingo).State = EntityState.Modified;
            }

            var query = (from c in dbContext.Cards
                         select c).ToList();

            RaffleCards raffleCards = new RaffleCards();
            foreach (Card card in query)
            {
                
                ViewBag.RaffleNumbers = raffleCards.CheckCardHits(card);
            }

            return View(bingo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
