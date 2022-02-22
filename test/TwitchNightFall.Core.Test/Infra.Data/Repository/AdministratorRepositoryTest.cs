using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Infra.Data;
using TwitchNightFall.Core.Infra.Data.Repository;
using TwitchNightFall.Domain.Entities;
using Xunit;

namespace TwitchNightFall.Core.Test.Infra.Data.Repository;

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

    [Fact]
    public void AddRange_SaveAdministrators()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("452EFA7A-A3F5-40CB-8963-EAE19C6C8D2D")
            .Options;

        using var writeContext = new ApplicationDbContext(options);
        using var repository = new AdministratorRepository(writeContext);

        var administrators = new List<Administrator>() { _administratorOne, _administratorTwo };

        repository.AddRange(administrators);

        writeContext.SaveChanges();

        using var readContext = new ApplicationDbContext(options);

        readContext.Administrator.ToList()
            .Should()
            .NotBeNull().And
            .BeEquivalentTo(administrators).And
            .ContainEquivalentOf(_administratorOne).And
            .ContainEquivalentOf(_administratorTwo).And
            .HaveCount(administrators.Count).And
            .BeInAscendingOrder(x => x.CreatedBy);
    }

    [Fact]
    public void Update_SaveAndUpdateAdministrator()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("ACCBC785-91E3-462E-BC10-8663EF3433E8")
            .Options;

        using var writeContext = new ApplicationDbContext(options);
        using var repository = new AdministratorRepository(writeContext);

        repository.Add(_administratorOne);

        writeContext.SaveChanges();

        var administrator = writeContext.Administrator.ToList().Single();

        administrator.Firstname.Should().Be("Sadeq");
        administrator.IsActive.Should().BeFalse();

        _administratorOne.Firstname = "Mohammad Sadeq";
        _administratorOne.IsActive = true;

        repository.Update(_administratorOne);

        writeContext.SaveChanges();

        using var readContext = new ApplicationDbContext(options);

        administrator = readContext.Administrator.ToList().Single();

        administrator.Firstname.Should().Be("Mohammad Sadeq");
        administrator.IsActive.Should().BeTrue();
    }

    [Fact]
    public void UpdateRange_SaveAndUpdateAdministrators()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("3AB0FB67-D0A7-4254-B0D4-E2765C03607D")
            .Options;

        using var writeContext = new ApplicationDbContext(options);
        using var repository = new AdministratorRepository(writeContext);

        repository.AddRange(new List<Administrator>() { _administratorOne, _administratorTwo });

        writeContext.SaveChanges();

        _administratorOne.Firstname = "Mohammad Sadeq";
        _administratorOne.IsActive = true;

        _administratorTwo.Firstname = "Seyed Javad";
        _administratorTwo.IsActive = true;

        repository.UpdateRange(new List<Administrator>() { _administratorOne, _administratorTwo });

        writeContext.SaveChanges();

        using var readContext = new ApplicationDbContext(options);

        var administrators = readContext.Administrator.ToList();

        administrators.Should()
            .BeEquivalentTo(new List<Administrator>() { _administratorOne, _administratorTwo }).And
            .ContainEquivalentOf(_administratorOne).And
            .ContainEquivalentOf(_administratorTwo).And
            .HaveCount(administrators.Count).And
            .BeInAscendingOrder(x => x.ModifiedAt);

        administrators.FirstOrDefault(x => x.Firstname == "Mohammad Sadeq")
            .Should()
            .NotBeNull().And
            .BeEquivalentTo(_administratorOne);

        administrators.FirstOrDefault(x => x.Firstname == "Seyed Javad")
            .Should()
            .NotBeNull().And
            .BeEquivalentTo(_administratorTwo);
    }
}