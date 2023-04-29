using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020ZR601_2020MG601.Models;

namespace P2_2020ZR601_2020MG601.Controllers
{
    public class casosController1 : Controller
    {
        private readonly casosDbContext _casosDbContext;
        public casosController1(casosDbContext casosDbContext) 
        {
            _casosDbContext = casosDbContext;
        }

        public IActionResult Index()
        {

            var listaDepartamentos = (from d in _casosDbContext.Departamento
                                      select d).ToList();
            ViewData["listaDepartamentos"] = new SelectList(listaDepartamentos, "IdDepartamento", "Departamento");

            var listaGenero = (from g in _casosDbContext.Generos
                               select g).ToList();
            ViewData["listaGeneros"] = new SelectList(listaGenero, "IdGenero", "Genero");

            var listadoCasos = (from c in _casosDbContext.Casos
                              join d in _casosDbContext.Departamento on c.IdDepartamento equals d.IdDepartamento
                              join g in _casosDbContext.Generos on c.IdGenero equals g.IdGenero
                              select new
                              {
                                  departamento = d.Departamento,
                                  genero = g.Genero,
                                  confirmados = c.Confirmados,
                                  recuperados = c.Recuperados,
                                  fallecidos = c.Fallecidos,
                              }).ToList();
            ViewData["listadodeCasos"] = listadoCasos;

            return View();
        }

        public IActionResult CrearRegistro(casos nuevosCasos)
        {
            _casosDbContext.Add(nuevosCasos);
            _casosDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
