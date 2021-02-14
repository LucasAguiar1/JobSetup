﻿using BridgestoneLibras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LHH.Controllers
{
    public class RespostaPerguntaController : Controller
    {
        // GET: RespostaPerguntaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RespostaPerguntaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RespostaPerguntaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RespostaPerguntaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RespostaPerguntaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RespostaPerguntaController/Edit/5
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

        // GET: RespostaPerguntaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RespostaPerguntaController/Delete/5
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


        public ActionResult RespostaPergunta(PerguntaModel collectionPergunta)
        {
            return View();
        }
    }
}
