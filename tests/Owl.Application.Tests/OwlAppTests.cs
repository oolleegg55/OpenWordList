using Moq;

using Owl.Domain;
using Owl.Domain.Model;

namespace Owl.Application;

public class OwlAppTests
{
    [Fact]
    public async Task GetFullWordListAsync_ShouldReturnWordListFullInfo()
    {
        // Arrange
        var wordListId = new Guid("0D680EBF-C524-45A5-A989-E3A947F7D00B");
        var wordListName = "TestName1";

        var wordListRepo = new Mock<IWordListRepository>();
        wordListRepo.Setup(x => x.GetWordListAsync(It.Is<Guid>(id => id == wordListId)))
            .ReturnsAsync(new WordList() { Id = wordListId, Name = wordListName });

        var app = new OwlApp(wordListRepo.Object);

        // Act
        var result = await app.GetFullWordListAsync(wordListId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(wordListId, result.Id);
        Assert.Equal(wordListName, result.Name);
    }

    [Fact]
    public async Task CreateWordList_ShouldCompleteSuccessfully()
    {
        // Arrange
        var wordListName = "TestName";

        var wordListRepo = new Mock<IWordListRepository>();
        var app = new OwlApp(wordListRepo.Object);

        // Act
        var result = await app.CreateWordListAsync(wordListName);

        // Assert
        wordListRepo.Verify(
            x => x.CreateWordListAsync(It.Is<WordList>(wl => wl.Name == wordListName)),
            Times.Once);
    }
}
