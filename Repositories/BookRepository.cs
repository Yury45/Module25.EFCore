using Module25.Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Homework.Repositories
{
    public class BookRepository
    {
        public Book Add(Book book)
        {
            using(var db = new AppContext())
            {
                db.Books.Add(book);
                db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Added; 
                db.SaveChanges();
                return book;
            }
        }

        public Book UpdateById(int bookId, string title, string author,
             string kind, DateTime created, int? userId)
        {
            using(var db = new AppContext())
            {
                var book = GetById(bookId);

                book.Title = title;
                book.Author = author;
                book.Created = created;
                book.Kind = kind;
                book.UserId = userId;
                book.User = db.Users.Where(x=> x.Id == userId).FirstOrDefault();

                db.Books.Update(book);
                db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return book;
            }
        }

        public Book Delete(Book book)
        {
            using(var db = new AppContext())
            {
                db.Remove(book);
                db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();

                return book;
            }
        }

        public Book DeleteById(int bookId)
        {
            using (var db = new AppContext())
            {
                var book = GetById(bookId);

                db.Remove(book);
                db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();

                return book;
            }
        }

        public Book? GetById(int id)
        {
            using(var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(x => x.Id == id);
                return book;

            }
        }

        public List<Book>? GetAll() 
        {
            using( var db = new AppContext())
            {
                var books = db.Books.ToList();
                return books;
            }
        }

        #region Методы поиска книг
        public List<Book> GetByCreation(DateTime firstDate, DateTime secondDate)
        {
            using( var db = new AppContext())
            {
                var books = db.Books.Where(x => x.Created >= firstDate && x.Created <= secondDate).ToList();

                return books;
            }
        }

        public List<Book> GetByAuthor(string author)
        {
            using( var db = new AppContext())
            {
                var books = db.Books.Where(x => x.Author == author).ToList();

                return books;
            }
        }

        public List<Book> GetByKind(string kind)
        {
            using (var db = new AppContext())
            {
                var books = db.Books.Where(x => x.Kind == kind).ToList();

                return books;
            }
        }

        public List<Book> GetByKindAndDate(string kind, DateTime firstDate, DateTime secondDate)
        {
            using (var db = new AppContext())
            {
                var books = db.Books.Where(x => x.Kind == kind).Where(x => x.Created >= firstDate && x.Created <= secondDate).ToList();

                return books;
            }
        }

        public bool IsAvailable(string title, string author)
        {
            using ( var db = new AppContext())
            {
                var isAvailable = db.Books.Any(x => x.Title == title && x.Author == author);

                return isAvailable; 
            }
        }

        public bool IsOnHands(int? userId, int bookId) 
        {
            using( var db = new AppContext())
            {

                var IsOnHands = db.Books.Where(x=>x.Id == bookId).Any(x=> x.UserId == userId);
                return IsOnHands;
                
            }
        }

        public Book GetLastBook()
        {
            using (var db = new AppContext())
                return db.Books.OrderBy(x => x.Created).LastOrDefault();
        }

        public List<Book> GetAllOrderedByTitle()
        {
            using ( var db = new AppContext())
                return db.Books.OrderBy(x=> x.Title).ToList();
        }

        public List<Book> GetAllOrderedByYears()
        {
            using ( var db = new AppContext())
                return db.Books.OrderByDescending(x => x.Created).ToList();
        }
        #endregion

        public Book GiveBook(int bookId, int userId)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(x => x.Id == bookId);
                var user = db.Users.FirstOrDefault(x => x.Id == userId);

                book.UserId = userId;
                book.User = user;

                user.Books.Add(book);
                db.Update(book);
                db.Update(user);

                db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return book;
            }
        }
    }
}
