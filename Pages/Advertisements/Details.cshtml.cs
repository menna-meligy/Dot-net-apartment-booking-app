﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using otthanbazar.Data;

namespace otthanbazar.Pages.Advertisements
{
    public class DetailsModel : PageModel
    {
        private readonly otthanbazar.Data.ApplicationDbContext _context;

        public DetailsModel(otthanbazar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Advertisement Advertisement { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Advertisements == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements.FirstOrDefaultAsync(m => m.Id == id);
            if (advertisement == null)
            {
                return NotFound();
            }
            else 
            {
                Advertisement = advertisement;
            }
            return Page();
        }
    }
}
