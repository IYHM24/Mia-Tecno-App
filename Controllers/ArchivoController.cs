using Mia_Tecno_Store_App.Data;
using Mia_Tecno_Store_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mia_Tecno_Store_App.Controllers
{
    public class ArchivoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArchivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(List<IFormFile> files)
        {
            List<Archivo> archivos = new List<Archivo>();
            if(files.Count > 0)
            {
                foreach (var file in files)
                {
                    var filePath = "C:\\Users\\LENOVO\\Desktop\\Archivos\\" + file.FileName; 
                    using(var stream = System.IO.File.Create(filePath))
                    {
                        file.CopyToAsync(stream);
                    }
                    double tamanio = file.Length;
                    tamanio = tamanio / 1000000;
                    tamanio = Math.Round(tamanio, 2);
                    Archivo archivo = new Archivo();
                    archivo.nombre = Path.GetFileNameWithoutExtension(file.FileName);
                    archivo.extension = Path.GetExtension(file.FileName).Substring(1);
                    archivo.tamanio = tamanio;
                    archivo.ubicacion = filePath;
                    archivos.Add(archivo);
                }
                _context.Archivo.AddRange(archivos);
                _context.SaveChanges();
            }
            return View();
        }
    }
}
