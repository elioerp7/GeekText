using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeekText.Data;

namespace GeekText.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet]
        public IActionResult ViewBooks(string search)
        {
            
            ApplicationDbContext context = HttpContext.RequestServices.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            //return View(context.GetAllBooks());
            if (search == null)
                return View(context.GetAllBooks());
            else
            {
                return View(context.GetAllBooks().Where(x => x.Title.Contains(search) || search == null).ToList());
            }
        }
        
    }
}