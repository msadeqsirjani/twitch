using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Infra.Data;
using TwitchNightFall.Core.Infra.Data.Repository;
using TwitchNightFall.Domain.Entities;
using Xunit;

namespace TwitchNightFall.Core.Test.Infra.Data.Repository
{
    public class AdministratorRepositoryTest
    {
        private readonly Administrator _administratorOne;
        private readonly Administrator _administratorTwo;

        public AdministratorRepositoryTest()
        {
            _administratorOne =
                new Administrator("Sadeq", "Sirjani", null, "msadeqsirjani", Security.Encrypt("Sa@123"));
            _administratorTwo =
                new Administrator("Javad", "Razavi", "http://localhost:5000/image", "javadrazavi",
                    Security.Encrypt("Ja@123"));
        }

        [Fact]
        public void Queryable_ReturnAdministrators()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("1C267B95-E6DD-4781-A94D-AE69315E9D11")
                .Options;

            using var writeContext = new ApplicationDbContext(options);

            var administrators = new List<Administrator> { _administratorOne, _administratorTwo };

            writeContext.AddRange(administrators);
            writeContext.SaveChanges();

            using var readContext = new ApplicationDbContext(options);

            using var repository = new AdministratorRepository(readContext);

            repository.Queryable().Should().BeEquivalentTo(administrators);
            repository.Queryable(false).Should().BeEquivalentTo(administrators);
        } 


        [Fact]
        public void QueryableWithCondition_ReturnAdministrators()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("AD8D0ABE-AAD4-472C-8856-CDDCF26A595C")
                .Options;

            using var writeContext = new ApplicationDbContext(options);

            var administrators = new List<Administrator> { _administratorOne, _administratorTwo };

            writeContext.AddRange(administrators);
            writeContext.SaveChanges();

            using var readContext = new ApplicationDbContext(options);

            using var repository = new AdministratorRepository(readContext);

            repository.Queryable(x => x.Firstname == "Sadeq").Should().BeEquivalentTo(new List<Administrator>() { _administratorOne });
            repository.Queryable(x => x.Lastname == "Razavi" && !string.IsNullOrEmpty(x.ProfileImageUrl), false).Should().BeEquivalentTo(new List<Administrator>() { _administratorTwo });
        }
    }
}
