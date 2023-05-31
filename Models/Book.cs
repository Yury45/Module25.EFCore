using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Homework.Models
{
    public class Book
    {
        //Внутренний ключ
        public int Id { get; set; }
        //Название книги
        public string? Title { get; set; }
        //Жанр книги
        public string? Kind { get; set; }
        //Автор книги
        public string? Author { get; set; }
        //Дата публикации
        public DateTime Created { get; set; }

        //Внешний ключ
        public int? UserId { get; set; }
        //Навигационное свойство
        public User? User { get; set; }

    }
}
