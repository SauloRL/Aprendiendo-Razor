using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Datos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class CrearModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public CrearModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        //propiedad de vinculacion 
        [BindProperty]
        public Curso Curso { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Curso.FechaCreacion = DateTime.Now;
            _contexto.Add(Curso);
            await _contexto.SaveChangesAsync();
            Mensaje = "Curso creado correctamente";
            return RedirectToPage("Index");
        }
    }
}
