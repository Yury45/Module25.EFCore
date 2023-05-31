using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Homework.Models
{
    public class User
    {
        //Первичный ключ
        public int Id { get; set; }
        //ФИО пользователя
        public string? Fullname { get; set; }
        //Электронная почта
        public string? Email { get; set; }

        //Список книг "на-руках" у пользователя
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
