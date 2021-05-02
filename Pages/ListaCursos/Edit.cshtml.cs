using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRazor3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudRazor3.Pages.ListaCursos
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Crud Curso { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet(int id)
        {
            Curso = await _db.Crud.FindAsync(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid) //si el model es valido, me actualiza los campos y me redirecciona al index
            {
                var CursoDesdeDb = await _db.Crud.FindAsync(Curso.Id);
                CursoDesdeDb.NombreCurso = Curso.NombreCurso;
                CursoDesdeDb.CantidadClases = Curso.CantidadClases;
                CursoDesdeDb.Precio = Curso.Precio;
                await _db.SaveChangesAsync();
                Mensaje = "Libro editado con exito!";

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
