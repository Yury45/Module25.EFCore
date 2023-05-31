using Module25.Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Homework.Repositories
{
    public class UserRepository
    {
        public User Add(User user) 
        {
            using(var db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

                return user;
            }
        }

        public User UpdateById(int id, string fullname)
        {
            using(var db = new AppContext())
            {
                var user = GetById(id);

                user.Fullname = fullname;

                db.Users.Update(user);
                db.SaveChanges();

                return user;
            }
        }

        public User DeleteById(int id)
        {
            using(var db = new AppContext())
            {
                var user = GetById(id);

                var books = db.Books.Where(x=> x.UserId == id).ToList();
                foreach(var book in books)
                {
                    book.UserId = null;
                }

                db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.Users.Remove(user);
                db.SaveChanges();

                return user;
            }
        }

        public User? GetById(int id) 
        {
            using(var db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == id);

                return user;
            }
        }
        
        public List<User> GetAll()
        {
            using (var db = new AppContext())
            {
                var users = db.Users.ToList();

                return users;
            }
        }

        public int GetBooksCount(int userId)
        {
            using (var db = new AppContext())
            {
                var count = db.Books.Where(x => x.UserId == userId).Count();
                return count;
            }
        }
    }
}