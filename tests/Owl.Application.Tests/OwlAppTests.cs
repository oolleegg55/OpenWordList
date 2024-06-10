using Moq;

using Owl.Application.ViewModels;
using Owl.Domain;
using Owl.Domain.Model;

namespace Owl.Application;

public class OwlAppTests
{
    [Fact]
    public async Task GetWordList()
    {
        // Arrange
        var wordListId = new Guid("0D680EBF-C524-45A5-A989-E3A947F7D00B");

        var wordListRepo = new Mock<IWordListRepository>();

        wordListRepo.Setup(x => x.GetWordListAsync(It.Is<Guid>(id => id == wordListId)))
            .ReturnsAsync(new WordList() { Id = wordListId, Name = "TestName1" });

        var app = new OwlApp(wordListRepo.Object);

        // Act
        var result = await app.GetFullWordListAsync(wordListId);

        // Assert
        var typedResult = Assert.IsType<WordListFullInfo>(result);
        Assert.Equal("TestName1", typedResult.Name);
        Assert.Equal(wordListId, typedResult.Id);
    }
}
