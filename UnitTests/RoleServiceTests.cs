using MainAPI.Models;
using MainAPI.Repository.Interfaces;
using MainAPI.Services;
using Moq;

namespace UnitTests
{
    public class RoleServiceTests
    {
        private readonly Mock<IRoleRepository> repo = new Mock<IRoleRepository>();

        [Fact]
        public void GetAll_ReturnsAllRoles()
        {
            //Arrange
            var roles = new List<Role>();

            Role admin = new Role
            {
                Id = System.Guid.NewGuid(),
                roleName = "Admin",
                CanViewAllUsers = true,
                isAdmin = true
            };
            Role user = new Role
            {
                Id = System.Guid.NewGuid(),
                roleName = "User",
                CanViewAllUsers = true,
                isAdmin = false
            };

            roles.Add(admin);
            roles.Add(user);

            repo.Setup(c => c.GetAll()).Returns(roles);
            RoleService _service = new RoleService(repo.Object);

            //Act
            List<Role> roleList = _service.GetAll().ToList();

            //Assert
            Assert.Equal(admin.Id, roleList[0].Id);
            Assert.Equal(user.Id, roleList[1].Id);
            Assert.NotEmpty(roleList);
        }
    }
}