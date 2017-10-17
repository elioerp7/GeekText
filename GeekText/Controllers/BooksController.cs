using GeekText.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                return View();
            else
            {
                return View(context.GetAllBooks().Where(x => x.Title.ToLower().Equals(field.ToLower()) || field == null).ToList());
            }
        }
        public IActionResult ShowAuthor(string field)
        {
            ApplicationDbContext context = HttpContext.RequestServices.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            //field.Replace("%20", " ");
            //return View(context.GetAllBooks());
            if (field == null)
                return View();
            else
            {
                return View(context.GetAllBooks().Where(x => x.Author.ToLower().Equals(field.ToLower()) || field == null).ToList());
            }
        }

    }
}