using Application.AggregatesModel.ServiceAggregate;
using Application.AggregatesModel.TotemAggregate;
using Bogus;
using FluentAssertions;

namespace Tests.AggregatesModel.TotemAggregate;

public class TotemTests 
{
    [Fact]
    public void Should_Instance_Totem_With_Name()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Name.FirstName();
        var attendancePassword = faker.Random.AlphaNumeric(1);
    
        // When
        var totem = new TotemModel(name, attendancePassword);
    
        // Then
        totem.Name.Should().Be(name);
    }

    [Fact]
    public void Should_Instance_Totem_With_AttendancePassword()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Name.FirstName();
        var attendancePassword = faker.Random.AlphaNumeric(1);
    
        // When
        var totem = new TotemModel(name, attendancePassword);
    
        // Then
        totem.AttendancePassword.Should().Be(attendancePassword);
    }

    [Fact]
    public void Should_Instance_Totem_With_Active_True()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Name.FirstName();
        var attendancePassword = faker.Random.AlphaNumeric(1);
    
        // When
        var totem = new TotemModel(name, attendancePassword);
    
        // Then
        totem.Active.Should().BeTrue();
    }

    [Fact]
    public void Should_Instance_Totem_With_Id_Valid()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Name.FirstName();
        var attendancePassword = faker.Random.AlphaNumeric(1);
    
        // When
        var totem = new TotemModel(name, attendancePassword);
    
        // Then
        totem.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void Should_Instance_Totem_With_Services_Empty()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Name.FirstName();
        var attendancePassword = faker.Random.AlphaNumeric(1);
    
        // When
        var totem = new TotemModel(name, attendancePassword);

        // Then
        totem.Services.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddServices_Services_Is_Not_Empty()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Name.FirstName();
        var attendancePassword = faker.Random.AlphaNumeric(1);
    
        // When
        var totem = new TotemModel(name, attendancePassword);
        List<ServiceTotemModel> services = new() {new ServiceTotemModel(faker.Name.FindName(), faker.Random.AlphaNumeric(10))};
        totem.AddServices(services);
        
        // Then
        totem.Services.Should().NotBeEmpty();
    }
}