using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.ORM;
using ERP.Mursheed.Repositories;
using ERP.Mursheed.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class PersonTest
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
                Id = 2,
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
