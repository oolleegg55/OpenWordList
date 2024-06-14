using Moq;

using Owl.WpfApp.AppWindow;
using Owl.WpfApp.Windows.CreateNewWordList;

namespace Owl.WpfApp.UnitTests.Windows.CreateNewWordList;

public class CreateNewWordListVmTests
{
    [Fact]
    public void CancelsCorrectly()
    {
        // Arrange
        var viewModel = new CreateNewWordListVm();
        var windowMock = new Mock<IAppWindow>();
        viewModel.Window = windowMock.Object;

        // Act
        viewModel.CancelCommand.Execute(null);

        // Assert
        Assert.True(viewModel.IsCanceled);
        windowMock.Verify(w => w.Close(), Times.Once);
    }

    [Fact]
    public void CreatesCorrectly()
    {
        // Arrange
        var viewModel = new CreateNewWordListVm();
        var windowMock = new Mock<IAppWindow>();
        viewModel.Window = windowMock.Object;

        // Act
        viewModel.CreateCommand.Execute(null);
        viewModel.Name = "Test";

        // Assert
        Assert.False(viewModel.IsCanceled);
        windowMock.Verify(w => w.Close(), Times.Once);

        Assert.Equal("Test", viewModel.Name);
    }
}
