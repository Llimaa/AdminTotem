using Application.AggregatesModel.ServiceAggregate;
using Application.Share;
using Moq;

namespace Tests.AggregatesModel.ServiceAggregate;

public class ServiceTotemHandlerTests 
{
    [Fact]
    public void Should_Handler_Add_Service_Totem_Command_Used_Once()
    {
        // Given
        AddServiceCommand command = new();
        var cancellationToken = new CancellationToken();
        var mock = new Mock<IHandler<AddServiceCommand>>();
        mock.Setup(_ =>  _.HandlerAsync(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.HandlerAsync(command);
    
        // Then
        mock.Verify(_ => _.HandlerAsync(It.IsAny<AddServiceCommand>(), cancellationToken),Times.Once);
    }

    [Fact]
    public void Should_Handler_Active_Service_Totem_Command_Used_Once()
    {
        // Given
        ActiveServiceCommand command = new();
        var cancellationToken = new CancellationToken();
        var mock = new Mock<IHandler<ActiveServiceCommand>>();
        mock.Setup(_ =>  _.HandlerAsync(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.HandlerAsync(command);
    
        // Then
        mock.Verify(_ => _.HandlerAsync(It.IsAny<ActiveServiceCommand>(), cancellationToken),Times.Once);
    }

    [Fact]
    public void Should_Handler_Inactive_Service_Totem_Command_Used_Once()
    {
        // Given
        InactiveServiceCommand command = new();
        var cancellationToken = new CancellationToken();
        var mock = new Mock<IHandler<InactiveServiceCommand>>();
        mock.Setup(_ =>  _.HandlerAsync(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.HandlerAsync(command);
    
        // Then
        mock.Verify(_ => _.HandlerAsync(It.IsAny<InactiveServiceCommand>(), cancellationToken),Times.Once);
    }
}