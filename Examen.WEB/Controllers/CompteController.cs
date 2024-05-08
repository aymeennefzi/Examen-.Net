using Castle.Core;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System;

namespace Examen.WEB.Controllers
{
    public class CompteController : Controller
        
    {
        ICompteService CS;
        IBanqueService BS;
        public CompteController(ICompteService cS, IBanqueService bS)
        {
            CS = cS;
            BS = bS;
        }



        // GET: CompteController
        public ActionResult Index()
        {
            return View(CS.GetAll());
        }

        // GET: CompteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompteController/Create
        public ActionResult Create() { 

          //Affichage de l'énumeration
          var typesCompte = Enum.GetValues(typeof(TypeCompte)).Cast<TypeCompte>();
          ViewBag.TypeCompteList = new SelectList(typesCompte);
          //Affichage de la liste des banques
          ViewBag.BanqueLisT = new SelectList(BS.GetAll(), "Code" , "Nom");
          return View();
        }

        // POST: CompteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compte collection)
        {
            try
            {
                CS.Add(collection);
                CS.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompteController/Edit/5
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

        // GET: CompteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompteController/Delete/5
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
