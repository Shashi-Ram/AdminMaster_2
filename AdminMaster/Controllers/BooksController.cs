using AdminMaster.Repository.Interface;
using AdminMaster.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMaster.Controllers
{
    public class BooksController : Controller
    {
        public GenericInterface<BookWithAuthorViewModel> BookService { get; }
        public IBook BookService2 { get; }

        public BooksController(GenericInterface<BookWithAuthorViewModel> _book, IBook book)
        {
            BookService = _book;
            BookService2 = book;
        }

        

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetBooks()
        {
            var book = BookService.Getdata();
            return Json(book);
        }
        [HttpPost]
        public JsonResult DeleteBook(int id)
        {
            var result = BookService2.DeleteBook(id);
            if (result)
            {
                return Json(new { message = "Book Deleted Succesfully", Ok = true });
            }
            return Json(new { message = "Book not Deleted !", Ok = false});
        }
    }
}
