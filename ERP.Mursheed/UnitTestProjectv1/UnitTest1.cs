﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectv1
{
    [TestClass]
    public class UnitTest1
    {
        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = new UnitOfWork(new MursheedContext());
        }

        [TestMethod]
        public void Add()
        {
            var person = new Person()
            {
                Id = 1,
                Firstname = "Parviz",
                Lastname = "Aliyev",
                FatherName = "Rovshan",
                Email = "parvizra@code.edu.az"
            };

            var insertedPersonResult = _unitOfWork.Repository<Person>().Add(person);
            Assert.IsTrue(insertedPersonResult.IsSuccess);
        }
    }
}