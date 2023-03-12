using Application.AggregatesModel.TotemAggregate;
using Application.Share;
using Moq;

namespace Tests.AggregatesModel.TotemAggregate;

public class TotemHandlerTests 
{
    [Fact]
    public void Should_Handler_Add_Service_Totem_Command_Used_Once()
    {
        // Given
        AddTotemCommand command = new();
        var cancellationToken = new CancellationToken();
        var mock = new Mock<IHandler<AddTotemCommand>>();
        mock.Setup(_ =>  _.HandlerAsync(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.HandlerAsync(command);
    
        // Then
        mock.Verify(_ => _.HandlerAsync(It.IsAny<AddTotemCommand>(), cancellationToken),Times.Once);
    }
}