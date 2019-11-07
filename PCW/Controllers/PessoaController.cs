using PCW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PCW.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoasDAL pes;
        public PessoaController(IPessoasDAL pessoas)
        {
            pes = pessoas;

        }
        public IActionResult Index()
        {
            List<Pessoas> listaPessoas = new List<Pessoas>();
            
            listaPessoas = pes.GetAllPessoas().ToList();

           

            return View(listaPessoas);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Pessoas pessoas = pes.GetPessoas(id);
            if (pessoas == null)
            {
                return NotFound();
            }
            return View(pessoas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Pessoas pessoas)
        {

            if (ModelState.IsValid)
            {
                pes.AddPessoas(pessoas);
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
            
                 return NotFound();
            }
            Pessoas pessoas = pes.GetPessoas(id);
            if (pessoas == null)
            {
                return NotFound();
            }
            return View(pessoas);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Pessoas pessoas)
        {
            if (id != pessoas.SEQPESSOA)
            {
               
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                pes.UpdatePessoas(pessoas);
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Pessoas pessoas = pes.GetPessoas(id);
            if (pessoas == null)
            {
                return NotFound();
            }
            return View(pessoas);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            pes.DeletePessoas(id);
            return RedirectToAction("Index");
        }

        public JsonResult ValidaCPF(string data)
        {
            bool cpfValido = Util.ValidaCPF(data.Replace(".","").Replace(".","").Replace("-",""));

            var result = new { Mensagem = cpfValido };

            return Json(new { valido = cpfValido });
        }

    }


}