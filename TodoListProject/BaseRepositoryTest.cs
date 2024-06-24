using AuthenticationLoginAndRegistration.Contracts;
using AuthenticationLoginAndRegistration.Data;
using AuthenticationLoginAndRegistration.Data.Entities;
using AuthenticationLoginAndRegistration.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TodoListProject
{
    [TestClass]
    public class BaseRepositoryTest
    {

        private Mock<ApplicationDbContext> _db;
        private BaseRepository<Todo> _repo;

        [TestInitialize]
        public void Initialize() { }

        [TestMethod]
        public void CreateTestMethod1()
        {
        }
    }
}