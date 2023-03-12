using System.Text.RegularExpressions;
using Application.AggregatesModel.ServiceAggregate;
using Bogus;
using FluentAssertions;

namespace Tests.AggregatesModel.ServiceAggregate;

public class ServiceTotemTests 
{
    [Fact]
    public void Should_Instance_Service_Totem_With_Name() 
    {
        //Given
        Faker fake = new("en");
        var name = fake.Name.FirstName();
        var description = fake.Random.AlphaNumeric(10);

        //When
        var serviceTotem = new Service(name, description);

        //Then
        serviceTotem.Name.Should().Be(name);
    }

    [Fact]
    public void Should_Instance_Service_Totem_With_Description() 
    {
        //Given
        Faker fake = new("en");
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);

        //When
        var serviceTotem = new Service(name, description);

        // Then
        serviceTotem.Description.Should().Be(description);
    }

    [Fact]
    public void Should_Instance_Service_Totem_With_Active_True()
    {
        // Given
        Faker fake = new("en");
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
    
        // Then
        serviceTotem.Active.Should().BeTrue();
    }

    [Fact]
    public void Should_Instance_Service_Totem_With_Id_Valid()
    {
        // Given
        Faker fake = new("en");
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
    
        // Then
        serviceTotem.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void Should_Instance_Service_Totem_With_UpdatedAt_Null()
    {
         // Given
        Faker fake = new("en"); 
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
    
        // Then
        serviceTotem.UpdatedAt.Should().BeNull();
    }

    [Fact]
    public void Should_Update_Service_Totem_With_UpdatedAt_Not_Null()
    {
         // Given
        Faker fake = new("en"); 
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
        serviceTotem.Update(fake.Name.FirstName(), fake.Random.AlphaNumeric(20));
    
        // Then
        serviceTotem.UpdatedAt.Should().NotBeNull();
    }
    
    [Fact]
    public void Should_Update_Service_Totem_With_New_Name()
    {
         // Given
        Faker fake = new("en"); 
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);

        var newName = fake.Name.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
        serviceTotem.Update(newName, description);
    
        // Then
        serviceTotem.Name.Should().Be(newName);
    }

    [Fact]
    public void Should_Update_Service_Totem_With_New_Description()
    {
         // Given
        Faker fake = new("en"); 
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);

        var newDescription = fake.Name.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
        serviceTotem.Update(name, newDescription);
    
        // Then
        serviceTotem.Description.Should().Be(newDescription);
    }

    [Fact]
    public void Should_InactiveServiceTotem_Service_Totem_With_Active_False()
    {
         // Given
        Faker fake = new("en"); 
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
        serviceTotem.InactiveServiceTotem();
    
        // Then
        serviceTotem.Active.Should().BeFalse();
    }

        [Fact]
    public void Should_ActiveServiceTotem_Service_Totem_With_Active_True()
    {
         // Given
        Faker fake = new("en"); 
        var name = fake.Name.FindName();
        var description = fake.Random.AlphaNumeric(10);
    
        // When
        var serviceTotem = new Service(name, description);
        serviceTotem.InactiveServiceTotem();
        serviceTotem.ActiveServiceTotem();
    
        // Then
        serviceTotem.Active.Should().BeTrue();
    }
}