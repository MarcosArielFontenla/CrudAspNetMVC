using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRazor3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudRazor3.Pages.ListaCursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Crud> Cursos { get; set; } // IEnumerable de tipo Crud para traerme todas las propiedades.

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Cursos = await _db.Crud.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var curso = await _db.Crud.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }
            _db.Crud.Remove(curso);
            await _db.SaveChangesAsync();

            Mensaje = "Curso borrado con exito!";

            return RedirectToPage("Index");
        }
    }
}
