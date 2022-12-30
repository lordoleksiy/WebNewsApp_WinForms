using FluentAssertions;
using NUnit.Framework;
using WebNewsApp.DAL.Repositories;

namespace WebNewsAppDal.Tests
{
    public class Tests
    {
        private EFUnitOfWork unitOfWork;
        [OneTimeSetUp]
        public void Setup()
        {
            unitOfWork = new EFUnitOfWork();
        }

        [Test]
        public void Test1()
        {
            var users = unitOfWork.UserRepository.GetAll();
            users.Should().NotBeNullOrEmpty();
        }
    }
}