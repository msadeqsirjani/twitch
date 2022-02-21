using System.Collections.Generic;
using System.Linq;
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

            repository.Queryable(x => x.Firstname == "Sadeq").Should()
                .NotBeNull().And
                .BeEquivalentTo(new List<Administrator>() { _administratorOne });

            repository.Queryable(x => x.Lastname == "Razavi" && !string.IsNullOrEmpty(x.ProfileImageUrl), false).Should()
                .NotBeNull().And
                .BeEquivalentTo(new List<Administrator>() { _administratorTwo });
        }

        [Fact]
        public void FirstOrDefault_ReturnAtLeaseOneAdministrator()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("600C3C35-C6B0-406A-8B61-997950EDC4B4")
                .Options;

            using var writeContext = new ApplicationDbContext(options);

            writeContext.Add(_administratorOne);
            writeContext.SaveChanges();

            using var readContext = new ApplicationDbContext(options);

            using var repository = new AdministratorRepository(readContext);

            repository.FirstOrDefault(x => x.Firstname == "Sadeq").Should()
                .NotBeNull().And
                .BeEquivalentTo(_administratorOne);

            repository.FirstOrDefault(x => x.Lastname == "").Should().BeNull();
        }

        [Fact]
        public void Add_SaveAdministrator()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("D1A4A1E3-0F44-45B4-99A5-B57D3948AAD0")
                .Options;

            using var writeContext = new ApplicationDbContext(options);
            using var repository = new AdministratorRepository(writeContext);

            repository.Add(_administratorOne);

            writeContext.SaveChanges();

            using var readContext = new ApplicationDbContext(options);

            var administrator = readContext.Administrator.ToList().Single();

            administrator.Should()
                .NotBeNull().And
                .BeEquivalentTo(_administratorOne);
        }
    }
}
