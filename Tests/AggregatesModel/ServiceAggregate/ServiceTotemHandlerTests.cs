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
        AddServiceTotemCommand command = new();
        var cancellationToken = new CancellationToken();
        var mock = new Mock<IHandler<AddServiceTotemCommand>>();
        mock.Setup(_ =>  _.Handler(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.Handler(command);
    
        // Then
        mock.Verify(_ => _.Handler(It.IsAny<AddServiceTotemCommand>(), cancellationToken),Times.Once);
    }

    [Fact]
    public void Should_Handler_Active_Service_Totem_Command_Used_Once()
    {
        // Given
        ActiveServiceTotemCommand command = new();
        var cancellationToken = new CancellationToken();
        var mock = new Mock<IHandler<ActiveServiceTotemCommand>>();
        mock.Setup(_ =>  _.Handler(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.Handler(command);
    
        // Then
        mock.Verify(_ => _.Handler(It.IsAny<ActiveServiceTotemCommand>(), cancellationToken),Times.Once);
    }

    [Fact]
    public void Should_Handler_Inactive_Service_Totem_Command_Used_Once()
    {
        // Given
        InactiveServiceTotemCommand command = new();
        var cancellationToken = new CancellationToken();
        var mock = new Mock<IHandler<InactiveServiceTotemCommand>>();
        mock.Setup(_ =>  _.Handler(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.Handler(command);
    
        // Then
        mock.Verify(_ => _.Handler(It.IsAny<InactiveServiceTotemCommand>(), cancellationToken),Times.Once);
    }
}