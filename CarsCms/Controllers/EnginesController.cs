using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsCms.Models;
using CarsCms.Repository.Interfaces;
using CarsCms.ViewModels;
using CarsCms.Validation;

namespace CarsCms.Controllers
{
    public class EnginesController : Controller
    {
        private IEngineRepository _engineRepository;
        

        public EnginesController(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
            
        }
        // GET: Cars
        public ActionResult Index()
        {
            var engineVM = new VMEngine { EngineList = new List<Engine>() };
          
            
                engineVM.EngineList = _engineRepository.GetWhere(x => x.Id > 0);
            
            return View(engineVM);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var engineVM = new VMEngine();
            engineVM.Engine = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            
            if (engineVM.Engine == null)
            {
                return HttpNotFound();
            }
            return View(engineVM);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMEngine model)
        {

            //w kontrolerze dodajemy walidację - wywołujemy, żeby zadziałało, usuwamy isValid, bo to odnosi do dataannotation
            //to samo robimy dla edit
            var validator = new EngineValidator();
            var result = validator.Validate(model.Engine);
            if (result.Errors.Any())
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            else
            {
                _engineRepository.Create(model.Engine);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var engineVM = new VMEngine();
            engineVM.Engine = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            
            if (engineVM.Engine == null)
            {
                return HttpNotFound();
            }
            return View(engineVM);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMEngine model)
        {
            var validator = new EngineValidator();
            var result = validator.Validate(model.Engine);
            if (result.Errors.Any())
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            else
            {
                _engineRepository.Create(model.Engine);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var engineVM = new VMEngine();
            engineVM.Engine = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            
            if (engineVM.Engine == null)
            {
                return HttpNotFound();
            }
            return View(engineVM);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)

        {
            Engine engine = _engineRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _engineRepository.Delete(engine);
            return RedirectToAction("Index");
        }

    }
}
