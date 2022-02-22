using System.Linq;
using FluentAssertions;
using TwitchNightFall.Core.Application.Validators;
using TwitchNightFall.Core.Application.ViewModels.Administrator;
using Xunit;

namespace TwitchNightFall.Core.Test.Application.Validators;

public class AdministratorDtoValidatorTest
{
    [Fact]
    public void CreateAdministratorDtoInCorrectWay()
    {
        var administratorDto = new AdministratorDto
        {
            Firstname = "Mohammad Sadeq",
            Lastname = "Sirjani",
            Username = "msadeqsirjani"
        };

        var validator = new AdministratorDtoValidator();
        var validation = validator.Validate(administratorDto);

        validation.IsValid.Should().BeTrue();
        validation.Errors.Should()
            .BeNullOrEmpty().And
            .HaveCount(0);
    }

    [Fact]
    public void CreateAdministratorDto_ٌWithEmptyUsername()
    {
        var administratorDto = new AdministratorDto
        {
            Firstname = "Mohammad Sadeq",
            Lastname = "Sirjani",
            Username = ""
        };

        var validator = new AdministratorDtoValidator();
        var validation = validator.Validate(administratorDto);

        validation.IsValid.Should().BeFalse();
        validation.Errors.Select(x => x.ErrorMessage)
            .Should()
            .NotBeNull().And
            .HaveCount(1).And
            .ContainEquivalentOf("Username cannot be empty");
    }

    [Fact]
    public void CreateAdministratorDto_ٌWithTooLongUsername()
    {
        var administratorDto = new AdministratorDto
        {
            Firstname = "Mohammad Sadeq",
            Lastname = "Sirjani",
            Username = "C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5"
        };

        var validator = new AdministratorDtoValidator();
        var validation = validator.Validate(administratorDto);

        validation.IsValid.Should().BeFalse();
        validation.Errors.Select(x => x.ErrorMessage)
            .Should()
            .NotBeNull().And
            .HaveCount(1).And
            .ContainEquivalentOf("Username can not be more than 250 characters");
    }

    [Fact]
    public void CreateAdministratorDto_ٌWithTooLongFirstname()
    {
        var administratorDto = new AdministratorDto
        {
            Firstname = "C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5",
            Lastname = "Sirjani",
            Username = "0"
        };

        var validator = new AdministratorDtoValidator();
        var validation = validator.Validate(administratorDto);

        validation.IsValid.Should().BeFalse();
        validation.Errors.Select(x => x.ErrorMessage)
            .Should()
            .NotBeNull().And
            .HaveCount(1).And
            .ContainEquivalentOf("The First name can not be more than 250 characters");
    }

    [Fact]
    public void CreateAdministratorDto_ٌWithTooLongLastname()
    {
        var administratorDto = new AdministratorDto
        {
            Firstname = "Mohammad Sadeq",
            Lastname = "C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5",
            Username = "0"
        };

        var validator = new AdministratorDtoValidator();
        var validation = validator.Validate(administratorDto);

        validation.IsValid.Should().BeFalse();
        validation.Errors.Select(x => x.ErrorMessage)
            .Should()
            .NotBeNull().And
            .HaveCount(1).And
            .ContainEquivalentOf("Last name can not be more than 250 characters");
    }

    [Fact]
    public void CreateAdministratorDto_ٌWithMultiErrors()
    {
        var administratorDto = new AdministratorDto
        {
            Firstname = "C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5",
            Lastname = "C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5",
            Username = "C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5C13A21B0-5CF8-4F06-87F3-3EF182EEA6A5"
        };

        var validator = new AdministratorDtoValidator();
        var validation = validator.Validate(administratorDto);

        validation.IsValid.Should().BeFalse();
        validation.Errors.Select(x => x.ErrorMessage)
            .Should()
            .NotBeNull().And
            .HaveCount(3).And
            .ContainEquivalentOf("Username can not be more than 250 characters").And
            .ContainEquivalentOf("Last name can not be more than 250 characters").And
            .ContainEquivalentOf("Last name can not be more than 250 characters");
    }
}