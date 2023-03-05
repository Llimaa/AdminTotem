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
        mock.Setup(_ =>  _.Handler(command, cancellationToken)).Returns(Task.CompletedTask);
    
        // When
        mock.Object.Handler(command);
    
        // Then
        mock.Verify(_ => _.Handler(It.IsAny<AddTotemCommand>(), cancellationToken),Times.Once);
    }
}