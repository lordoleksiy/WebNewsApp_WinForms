using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebNewsApp.DAL.Repositories;

namespace Dal.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private EFUnitOfWork unitOfWork;
        [ClassInitialize]
        public void SetUp()
        {
            unitOfWork = new EFUnitOfWork();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var users = unitOfWork.UserRepository.GetAll();
            users.Should().NotBeNullOrEmpty();
        }
    }
}
