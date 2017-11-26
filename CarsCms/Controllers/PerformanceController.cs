using CarsCms.ApiConsumer;
using CarsCms.ApiConsumer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarsCms.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Performance
        public async Task<ActionResult> Index()
        {
            var client = new Client();
            var models = await client.GetAll(); //model jest taskiem, więc trzeba dodać await

            return View(models);
        }

        // GET: Performance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Performance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Performance/Create
        [HttpPost]
        public async Task<ActionResult> Create(Performance performance) // tutaj odwołujemy się do metody z ApiConsumer/Client
        {
            
                var client = new Client();
                var models = await client.SetPerformance(performance);

                return RedirectToAction("Index");
           
        }

        // GET: Performance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Performance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Performance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
