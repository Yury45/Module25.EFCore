using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Module25.Homework.Models;
using Module25.Homework.Repositories;
using System;

namespace Module25.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            var bookRepository = new BookRepository();

            #region Внесение тестовых данных пользователей в БД
            userRepository.Add(new User
            {
                Fullname = $"Кирилов Виктор Владимирович",
                Email = $"KVV@gmail.com",
                Books = new List<Book>()
            });

            userRepository.Add(new User
            {
                Fullname = $"Санник Сава Васильевич",
                Email = $"SSV@gmail.com",
                Books = new List<Book>()
            });
            #endregion

            #region Внесение тестовых данных книг в БД
            bookRepository.Add(new Book
            {
                Author = $"Лев Николаевич Толстой",
                Title = $"Война и мир",
                Kind = $"Роман",
                Created = new DateTime(1878, 10, 8),
                UserId = 1
            });

            bookRepository.Add(new Book
            {
                Author = $"Лев Николаевич Толстой",
                Title = $"Анна Каренина",
                Kind = $"Роман",
                Created = new DateTime(1878, 10, 8),
                UserId = 1
            });

            bookRepository.Add(new Book
            {
                Author = $"Лев Николаевич Толстой",
                Title = $"Холстомер",
                Kind = $"Рассказ",
                Created = new DateTime(1886, 7, 9)
            });


            bookRepository.Add(new Book
            {
                Author = $"Антон Павлович Чехов",
                Title = $"Тоска",
                Kind = $"Рассказ",
                Created = new DateTime(1886, 1, 4)
            });

            bookRepository.Add(new Book
            {
                Author = $"Антон Павлович Чехов",
                Title = $"Ионыч",
                Kind = $"Рассказ",
                Created = new DateTime(1898, 3, 8)
            });

            bookRepository.Add(new Book
            {
                Author = $"Чарльз Буковски",
                Title = $"Хлеб с ветчиной",
                Kind = $"Рассказ",
                Created = new DateTime(1982, 2, 8)
            });

            bookRepository.Add(new Book
            {
                Author = $"Чарльз Буковски",
                Title = $"Макулатура",
                Kind = $"Роман",
                Created = new DateTime(1994, 5, 8)
            });

            bookRepository.Add(new Book
            {
                Author = $"Джек Лондон",
                Title = $"Любовь к жизни",
                Kind = $"Рассказ",
                Created = new DateTime(1907, 9, 1),
                UserId = 2
            });
            #endregion

            var users = userRepository.GetAll();
            var books = bookRepository.GetAll();

            userRepository.UpdateById(2, "Леонид Владимирович Понамарев");

            bookRepository.UpdateById(8, "Нравственные письма Луцилию", "Луций Анней Сенека", "Философия", new DateTime(63, 1, 1), 1);

            bookRepository.DeleteById(4);

            bookRepository.GiveBook(5, 1);

            userRepository.GetBooksCount(1);
        }
    }
}