using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Tital = bookModel.Tital,
                Author = bookModel.Author,
                Description = bookModel.Description,
                LanguageId = bookModel.LanguageId,
                TotalPage = bookModel.TotalPage.HasValue ? bookModel.TotalPage.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();

            return newBook.Id;
        }     
        public async Task<List<BookModel>>GetAllBooks()
        {           
                return await _context.Books.Select(book => new BookModel() 
                {
                    Id = book.Id,
                    Tital = book.Tital,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    TotalPage = book.TotalPage
                }).ToListAsync();
        }
        public async Task<BookModel>GetBookById(int Id)
        {
            return await _context.Books.Where(x => x.Id == Id).Select(book => new BookModel() 
            {
                Id = book.Id,
                Tital = book.Tital,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                TotalPage = book.TotalPage
            }).FirstOrDefaultAsync();                                  
        }
        public List<BookModel> SearchBook(string booktital, string bookAuthor)
        {
            return null;
            //return BookDataSet().Where(x => x.Tital.Contains(booktital) || x.Author.Contains(bookAuthor)).ToList();
        }
        //private List<BookModel> BookDataSet()
        //{
        //    return new List<BookModel>()
        //    {
        //        new BookModel(){Id=1, Tital="MVC", Author="Chintan", Description="This is the description for the book MVC", Category="Programmming", Language="English", TotalPage=444},
        //        new BookModel(){Id=2, Tital="MVC core", Author="Sehu", Description="This is the description for the book MVC Core", Category="Programmming", Language="Hindi", TotalPage=555},
        //        new BookModel(){Id=3, Tital="Java", Author="Ripal", Description="This is the description for the book Java", Category="Secure Programmming", Language="English", TotalPage=666},
        //        new BookModel(){Id=4, Tital="Angular", Author="Shaurya", Description="This is the description for the book Angulae", Category="Frontend Programmming", Language="English", TotalPage=444},
        //        new BookModel(){Id=5, Tital="PHP", Author="Chintan", Description="This is the description for the book Php", Category="Programmming", Language="English", TotalPage=333},
        //        new BookModel(){Id=9, Tital="SQL", Author="Sehu", Description="This is the description for the book SQL", Category="Database", Language="English", TotalPage=1111}
        //    };
        //}
    }
}
