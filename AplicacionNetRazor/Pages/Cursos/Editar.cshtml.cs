using AplicacionNetRazor.Datos.Modelos;
using AplicacionNetRazor.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public EditarModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        //propiedad de vinculacion 
        [BindProperty]
        public Curso Curso { get; set; }

        [TempData]
        public string Mensaje { get; set; }


        public async Task OnGet(int id)
        {
            Curso = await _contexto.Curso.FindAsync(id);
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {                
                var CursoDesdeBD = await _contexto.Curso.FindAsync(Curso.id);
                    
                CursoDesdeBD.NombreCurso = Curso.NombreCurso;
                CursoDesdeBD.CantidadClases = Curso.CantidadClases;
                CursoDesdeBD.Precio = Curso.Precio;
                await _contexto.SaveChangesAsync();
                Mensaje = "Curso Editado correctamente";
                return RedirectToPage("Index");
                                    
            }

            return RedirectToPage();
        }

    }
}
