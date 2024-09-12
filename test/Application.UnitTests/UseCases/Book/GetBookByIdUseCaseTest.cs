using Application.Abstractions.Mappings;
using Application.DTOs.Requests.Book;
using Application.DTOs.Responses.Book;
using Application.UseCases.Book;
using Domain.Interfaces.Repositories.Book;
using Moq;

namespace Application.UnitTests.UseCases.Book;

public class GetBookByIdUseCaseTest
{
    private Mock<IBookMapper> MapperMock { get; } = new();
    private Mock<IBookReadOnlyRepository> ReadOnlyRepositoryMock { get; } = new();
    private GetBookByIdUseCase UseCase { get; }

    public GetBookByIdUseCaseTest()
    {
        UseCase = new GetBookByIdUseCase(MapperMock.Object, ReadOnlyRepositoryMock.Object);
    }

    [Fact]
    public async Task ShouldReturnGetBookByIdResponseWhenBookExists()
    {
        // Arrange
        var book = new Domain.Entities.Book(1, "Title", "Author");
        var request = new GetBookByIdRequest(book.Id);

        ReadOnlyRepositoryMock.Setup(r => r.GetBookByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(book);

        MapperMock.Setup(m => m.DomainToResponse(It.IsAny<Domain.Entities.Book>()))
            .Returns(new GetBookByIdResponse(book.Id, book.Title, book.Author));

        // Act
        var response = await UseCase.ExecuteAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(book.Id, response.Id);
        Assert.Equal(book.Title, response.Title);
        Assert.Equal(book.Author, response.Author);
    }

    [Fact]
    public async Task ShouldThrowExceptionWhenBookNotFound()
    {
        // Arrange
        var request = new GetBookByIdRequest(1);

        ReadOnlyRepositoryMock.Setup(r => r.GetBookByIdAsync(It.IsAny<int>()))
            .ThrowsAsync(new Exception("Book not found."));

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() => UseCase.ExecuteAsync(request));

        // Assert
        Assert.Equal("Book not found.", exception.Message);
    }
}