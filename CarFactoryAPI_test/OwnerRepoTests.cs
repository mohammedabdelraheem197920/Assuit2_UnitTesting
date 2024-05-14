using CarAPI.Entities;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;

namespace CarFactoryAPI_test
{
    public class OwnerRepoTests
    {
        private Mock<FactoryContext> factoryContextMock;

        private OwnerRepository ownerRepository;

        public OwnerRepoTests()
        {

            factoryContextMock = new Mock<FactoryContext>();


            ownerRepository = new OwnerRepository(factoryContextMock.Object);
        }

        [Fact]
        [Trait("Author", "Abdelraheem")]
        [Trait("Priority", "10")]
        public void Owner_Id_Ask_Owner10_Return_Owner()
        {
            // Arrange

            // Build the mock Data
            List<Owner> owners = new List<Owner>() { new Owner() { Id = 10 } };

            // setup called DbSets
            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);

            // Act 
            Owner owner = ownerRepository.GetOwnerById(10);

            // Aassert
            Assert.NotNull(owner);
        }

        [Fact]
        [Trait("Author", "Abdelraheem")]
        public void Get_all_owner_Return_list_of_owners()
        {

            List<Owner> owners = new List<Owner>() { new Owner() { Id = 10 } };

            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);


            List<Owner> owners1 = ownerRepository.GetAllOwners();


            Assert.NotNull(owners1);
        }
    }
}
