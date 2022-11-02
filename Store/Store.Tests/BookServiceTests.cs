﻿using Moq;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        //[Fact]
        //public void GetAllByQuery_WithIsbn_CallGetAllByIsbn()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();
        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
        //        .Returns(new[] { new Book(1, "", "", "") });

        //    bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
        //        .Returns(new[] { new Book(2, "", "", "") });

        //    var BookService = new BookService(bookRepositoryStub.Object);

        //    var validIsbn = "ISBN 12345-67890";
        //    var actual = BookService.GetAllByQuery(validIsbn);

        //    Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        //}


        [Fact]
        public void GetAllByQuery_WithAuthor_CallGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "","",0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var BookService = new BookService(bookRepositoryStub.Object);

            var invalidIsbn = "12345-67890";
            var actual = BookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithIsbn_CallGetAllByIsbn()
        {
            const int idOfIsdnSearch = 1;
            const int idOfAuthorSearch = 2;
            var bookRepository = new StubBookRepository();
            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                new Book(idOfIsdnSearch,"","","","",0m)
            };

            bookRepository.ResultOfGetAllByTitleOrAuthor = new[]
{
                new Book(idOfAuthorSearch,"","","","",0m)
            };


            var bookService = new BookService(bookRepository);

            var books = bookService.GetAllByQuery("ISBN 12345-67890");

            Assert.Collection(books, book => Assert.Equal(idOfIsdnSearch, book.Id));

        }
    }
}
