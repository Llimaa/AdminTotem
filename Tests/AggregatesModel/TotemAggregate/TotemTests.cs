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
        var totem = new Totem(name);
    
        // Then
        totem.Name.Should().Be(name);
    }

    [Fact]
    public void Should_Instance_Totem_With_Active_True()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Name.FirstName();
        var attendancePassword = faker.Random.AlphaNumeric(1);
    
        // When
        var totem = new Totem(name);
    
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
        var totem = new Totem(name);
    
        // Then
        totem.Id.Should().NotBe(Guid.Empty);
    }
}