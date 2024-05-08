using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.WEB.Controllers
{
    public class BanqueController : Controller
    {
        IBanqueService bs;

        public BanqueController(IBanqueService bs)
        {
            this.bs = bs;
        }

        // GET: BanqueController
        public ActionResult Index()
        {
            return View(bs.GetAll());
        }

        // GET: BanqueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BanqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BanqueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Banque collection)
        {
            try
            {
                bs.Add(collection);
                bs.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BanqueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BanqueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BanqueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BanqueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
