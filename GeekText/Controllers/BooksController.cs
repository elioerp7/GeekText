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
                return View(context.GetAllBooks().Where(x => x.Title.ToLower().Contains(search.ToLower()) ||
                                                             x.Author.ToLower().Contains(search.ToLower()) ||
                                                             x.Genre.ToLower().Contains(search.ToLower()) ||
                                                             x.ISBN.Contains(search) ||
                                                             x.Publisher.ToLower().Contains(search.ToLower()) ||
                                                             search == null).ToList());
            }
        }
        public IActionResult ShowBook(string field)
        {
            ApplicationDbContext context = HttpContext.RequestServices.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            //field.Replace("%20", " ");
            //return View(context.GetAllBooks());
            if (field == null)
                return View(context.GetAllBooks());
            else
            {
                return View(context.GetAllBooks().Where(x => x.Title.ToLower().Equals(field.ToLower()) || field == null).ToList());
            }
        }
        
    }
}