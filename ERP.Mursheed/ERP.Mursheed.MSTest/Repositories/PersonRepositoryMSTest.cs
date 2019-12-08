using System;
using System.Collections.Generic;
using System.Text;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.ORM;
using ERP.Mursheed.Repositories;
using ERP.Mursheed.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERP.Mursheed.MSTest.Repositories
{
    [TestClass]
    public class PersonRepositoryMSTest
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
