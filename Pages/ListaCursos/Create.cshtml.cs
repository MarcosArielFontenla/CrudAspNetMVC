using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudRazor3.Models;

namespace CrudRazor3.Pages.ListaCursos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Crud Curso { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _db.Add(Curso);
            await _db.SaveChangesAsync();
            Mensaje = "Curso creado correctamente!";

            return RedirectToPage("Index");
        }
        // si el ModelState no es valido, que me retorne a la pagina principal, sino agrega el curso y lo guarda y me redirecciona al index.

        

    }
}
