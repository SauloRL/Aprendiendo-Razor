using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Datos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public IndexModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Curso>Cursos { get; set; }
        
        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            if (ModelState.IsValid)
            {
                var curso = await _contexto.Curso.FindAsync(id);

                if (curso == null)
                {
                    return NotFound();
                }


                _contexto.Curso.Remove(curso);

                await _contexto.SaveChangesAsync();
                Mensaje = "Curso borrado con exito";
                return RedirectToPage("Index");

            }

            return RedirectToPage();
        }

    }
}
