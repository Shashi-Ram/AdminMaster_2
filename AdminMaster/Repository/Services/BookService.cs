using AdminMaster.Models;
using AdminMaster.Repository.Interface;
using AdminMaster.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMaster.Repository.Services
{
    public class BookService:GenericInterface<BookWithAuthorViewModel>,IBook
    {
        private MSDBContext dbContext;
        public BookService()
        {
            dbContext = new MSDBContext();
        }

        public bool DeleteBook(int id)
        {
            var book = dbContext.Books.SingleOrDefault(e => e.Id == id);
            if(book != null)
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<BookWithAuthorViewModel> Getdata()
        {
            var books = (from book in dbContext.Books
                         join
                         Author in dbContext.Author
                         on book.Author_Id equals Author.Id
                         select new BookWithAuthorViewModel()
                         {
                             Id=book.Id,
                             Title=book.Title,
                             Price=book.Price,
                             Quantity=book.Quantity,
                             Published_On=book.Published_On,
                             AuthorName=Author.Name,
                             AuthorEmail=Author.Email,
                             AuthorMobile=Author.Mobile
                         }).ToList();
            return books;
        }
    }
}
