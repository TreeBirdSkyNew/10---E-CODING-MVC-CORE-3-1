using _4___E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _4___E_CODING_DAL
{
    public static class DbInitializer
    {
        public static void Initialize(TemplateProjectDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TemplateProject.Any())
            {
                return;   // DB has been seeded
            }

            
        }

        
    }
}



