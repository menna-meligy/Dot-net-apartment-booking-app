using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using otthanbazar.Data;

namespace otthanbazar.Pages.Advertisements
{
    public class CreateModel : PageModel
    {
        private readonly otthanbazar.Data.ApplicationDbContext _context;

        public CreateModel(otthanbazar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Advertisement Advertisement { get; set; } = default!;
        public ActionResult OnGetZip(int zip) => new JsonResult(_context.Cities.FirstOrDefault(c => c.Zip
== zip.ToString()));

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Advertisements == null || Advertisement == null)
            {
                return Page();
            }

            _context.Advertisements.Add(Advertisement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


            var city = await _context.Cities.FirstOrDefaultAsync(c => c.Zip == c.Zip.ToString());

            if (city == null)
            {
                ModelState.AddModelError("Advertisement.CityZip", "Invalid Zip Code");
                return Page();
            }

            // Set the City property in the model
            Advertisement.City = city;

            // Save the advertisement into the database
            _context.Advertisements.Add(Advertisement);
            await _context.SaveChangesAsync();

            // Redirect to the listing page or another appropriate page
            return RedirectToPage("/Advertisements/Index");
        }
        public async Task<IActionResult> OnPostAsync(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                // Specify a folder where you want to save the uploaded images.
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // Create the folder if it doesn't exist.
                Directory.CreateDirectory(uploadFolder);

                // Generate a unique file name for the uploaded image (you can use other methods).
                var uniqueFileName = Path.Combine(uploadFolder, Path.GetRandomFileName() + Path.GetExtension(image.FileName));

                // Save the image to the server.
                using (var fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // You can save the uniqueFileName to a database or use it as needed.
                // Redirect or return a response as needed.
            }

            return Page();
        }
    }
}
