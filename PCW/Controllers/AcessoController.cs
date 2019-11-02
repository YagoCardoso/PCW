﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCW.Models;

namespace PCW.Controllers
{
    public class AcessoController : Controller
    {

        private readonly IPessoasDAL pes;
        public AcessoController(IPessoasDAL pessoas)
        {
            pes = pessoas;

        }

        // GET: Acesso
        public ActionResult Index()
        {
            return View();


        }

        // GET: Acesso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Acesso(string cpf)
        {
           var respotaURL = RedirectToAction("Erro", "Acesso");
           
            

            Pessoas p = new Pessoas();
            p = pes.GetUsu(Convert.ToInt32(cpf));

            var cpfUSuario = p;

            if(cpfUSuario.CPF != null)
            {
                respotaURL = RedirectToAction("Index", "Home");
            }

            return respotaURL;
           
        }

        public ActionResult Erro()
        {
            return View();
        }

        // GET: Acesso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acesso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Acesso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Acesso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Acesso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Acesso/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}