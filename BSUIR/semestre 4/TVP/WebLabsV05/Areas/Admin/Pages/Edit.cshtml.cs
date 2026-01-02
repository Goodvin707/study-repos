using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLabsV05.DAL.Data;
using WebLabsV05.DAL.Entities;

namespace WebLabsV05.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebLabsV05.DAL.Data.ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public EditModel(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Dish Dish { get; set; }
        [BindProperty]
        public IFormFile image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes
                .Include(d => d.Group).FirstOrDefaultAsync(m => m.DishId == id);

            if (Dish == null)
            {
                return NotFound();
            }
           ViewData["DishGroupId"] = new SelectList(_context.DishGroups, "DishGroupId", "GroupName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            string path="";
            // предыдущее изображение
            string previousImage = String.IsNullOrEmpty(Dish.Image)
                ? ""
                : Dish.Image;     
            if (image != null)
            {
                // новый файл изображения
                Dish.Image = Dish.DishId + Path.GetExtension(image.FileName);
                // путь для нового файла изображения
                path = Path.Combine(_environment.WebRootPath, "images", Dish.Image);   
            }

            _context.Attach(Dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                if(image!=null)
                {
                    // если было предыдущее изображение
                    if (!String.IsNullOrEmpty(previousImage))
                    {
                        // если файл существует
                        var fileInfo = _environment.WebRootFileProvider
                                            .GetFileInfo("/Images/" + previousImage);
                        if (fileInfo.Exists)
                        {
                            var oldPath = Path.Combine(_environment.WebRootPath, "images", previousImage);
                            // удалить предыдущее изображение
                            System.IO.File.Delete(oldPath);
                        }

                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        // сохранить новое изображение
                        await image.CopyToAsync(stream);
                    };
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(Dish.DishId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.DishId == id);
        }
    }
}
