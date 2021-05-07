using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookrepository = null;
        private readonly LanguageRepository _languagerepository = null;

        public BookController(BookRepository bookRepository, LanguageRepository languagerepository)
        {
            _bookrepository = bookRepository;
            _languagerepository = languagerepository;
        }
   
        public async Task<ActionResult>GetAllBooks()
        {
            var BookData = await _bookrepository.GetAllBooks();

            return View(BookData);
        }
        [Route("Book-Detail/{id}",Name ="BookDetailRoute")]
        public async Task<ActionResult> GetBookDetail(int id)
        {
            var Data = await _bookrepository.GetBookById(id);
            return View(Data);
        }
        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookrepository.SearchBook(bookName, authorName);
        }
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.Language = new SelectList(await _languagerepository.GetLanguage(), "Id","Name", 2);

            //To set default value in Dropdown
            //var model = new BookModel() 
            //{ 
            //    Language = "English"
            //};

            //In SelectList first parameter is list and second is default selected Language
            //(1-Way) ----- Using SelectList
            //ViewBag.Language = new SelectList(GetLanguage(),"Id","Language", 2);

            //(2-Way) ----- Using SelectListItem
            //ViewBag.Language = new List<SelectListItem>() 
            //{ 
            //    new SelectListItem(){Text="Hindi",Value="1"},
            //    new SelectListItem(){Text="English",Value="2",Disabled=true},
            //    new SelectListItem(){Text="Hindi",Value="3", Selected=true},
            //    new SelectListItem(){Text="Tamil",Value="4"}
            //};

            //(3-Way) ---- Using SelectListItem + SelectListGroup
            //var group1 = new SelectListGroup() { Name="Group1" };
            //var group2 = new SelectListGroup() { Name="Group2", Disabled=true};
            //var group3 = new SelectListGroup() { Name="Group3" };

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi",Value="1", Group=group1},
            //    new SelectListItem(){Text="English",Value="2",Group=group1},
            //    new SelectListItem(){Text="Hindi",Value="3", Group=group2},
            //    new SelectListItem(){Text="Tamil",Value="4",Group=group2},
            //    new SelectListItem(){Text="Dutch",Value="5",Group=group3},
            //    new SelectListItem(){Text="Franch",Value="6",Group=group3},
            //    new SelectListItem(){Text="Urdu",Value="7",Group=group3}
            //};

            //(4-Way) ---- Using SelectListItem + SelectListGroup
            //--4th wat is using the enum

            ViewBag.IsSuccess = isSuccess;//After successfully adding display the message
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AddNewBook(BookModel bookModel) 
        {
            if (ModelState.IsValid)
            {
                int id = await _bookrepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, bookId = id });
                }                
            }

            ViewBag.Language = new SelectList(await _languagerepository.GetLanguage(), "Id", "Name");

            //ViewBag.Language = new SelectList(new List<string>() { "Hindi", "English", "Gujarati" });
            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2", Disabled = true };
            //var group3 = new SelectListGroup() { Name = "Group3" };

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi",Value="1", Group=group1},
            //    new SelectListItem(){Text="English",Value="2",Group=group1},
            //    new SelectListItem(){Text="Hindi",Value="3", Group=group2},
            //    new SelectListItem(){Text="Tamil",Value="4",Group=group2},
            //    new SelectListItem(){Text="Dutch",Value="5",Group=group3},
            //    new SelectListItem(){Text="Franch",Value="6",Group=group3},
            //    new SelectListItem(){Text="Urdu",Value="7",Group=group3}
            //};
            //ModelState.AddModelError("", "This is my custom error message");
            return View();
        } 

        //private List<LanguageModel> GetLanguage()
        //{
        //    return new List<LanguageModel>()
        //    {
        //        new LanguageModel(){Id =1, Language="Hindi (One of the best language)"},
        //        new LanguageModel(){Id =2, Language="English (Globle Language)"},
        //        new LanguageModel(){Id =3, Language="Gujarati (Famous Language)"}
        //    };
            
        //}
    }
}
