using Mia_Tecno_Store_App.Data;
using Mia_Tecno_Store_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mia_Tecno_Store_App.Controllers
{
    public class ForrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Table()
        {
            return View(this.GettAllRegistry());
        }

        public List<Forros> GettAllRegistry()
        {
            var List = _context.Forros.ToList();
            return List;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Table(string nombre)
        {
            
            if(nombre != null)
            {
                ViewData["filtro"] = nombre;
            } else
            {
                ViewData["filtro"] = "ej. galaxy..";
            }

            ViewBag.nombre = nombre;

            var listFiltrada = _context.Forros.FromSqlRaw<Forros>("buscar {0}", nombre);
            return View(listFiltrada);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Forros forros)
        {
            if (forros.nombre != "" && forros.referencia != "" && forros.tipo != "" && forros.colores != "" && forros.marca != "")
            {
                var objectDb = _context.Forros.FromSqlRaw<Forros>("getMaxId").ToList();
                int idMax = objectDb[0].id_forro;

                //if(idMax == 0 || idMax == null)
                //{
                //    idMax = 1;
                //    forros.id_forro = idMax;
                //} else
                //{
                //    idMax = idMax + 1;
                //    forros.id_forro = idMax;
                //}
                
                if(forros.variante == "" || forros.variante == null)
                {
                    forros.variante = "x";
                }

                if(forros.variante_2 == "" || forros.variante_2 == null) {
                    forros.variante_2 = "x";
                }

                _context.Forros.Add(forros);
                _context.SaveChanges();

                TempData["mensaje"] = "el producto se agrgo con exito";
                return RedirectToAction("Table");
            }
                
            return View();

        }
        //public IActionResult Table()
        //{
        //    IEnumerable<Forros> listForros = _context.Forros.FromSqlRaw<Forros>("getAll").ToList();
        //    return View(listForros);
        //}

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var forros = _context.Forros.Find(id);

            if(forros == null)
            {
               return NotFound();
            }


            return View(forros);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Forros forros)
        {
            if (forros.nombre != "" && forros.referencia != "" && forros.tipo != "" && forros.colores != "" && forros.marca != "")
            {
                if (forros.variante == "" || forros.variante == null)
                {
                    forros.variante = "x";
                }

                if (forros.variante_2 == "" || forros.variante_2 == null)
                {
                    forros.variante_2 = "x";
                }

                _context.Forros.Update(forros);
                _context.SaveChanges();

                TempData["mensaje"] = "el producto se actualizo con exito";
                return RedirectToAction("Table");
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var forros = _context.Forros.Find(id);

            if (forros == null)
            {
                return NotFound();
            }


            return View(forros);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Forros forros)
        {
            if (forros.nombre != "" && forros.referencia != "" && forros.tipo != "" && forros.colores != "" && forros.marca != "")
            {
                if (forros.variante == "" || forros.variante == null)
                {
                    forros.variante = "x";
                }

                if (forros.variante_2 == "" || forros.variante_2 == null)
                {
                    forros.variante_2 = "x";
                }

                _context.Forros.Remove(forros);
                _context.SaveChanges();

                TempData["mensaje"] = "el producto se elimino con exito";
                return RedirectToAction("Table");
            }

            return View();

        }

    }
}
