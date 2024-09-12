using Application.Abstractions.Mappings;
using Application.Abstractions.UseCases.Book;
using Application.DTOs.Responses.Book;
using Domain.Interfaces.Repositories.Book;

namespace Application.UseCases.Book;

public class GetBookByIdUseCase(IBookMapper mapper, IBookReadOnlyRepository readOnlyRepository)
    : IGetBookByIdUseCase
{
    private IBookMapper Mapper { get; } = mapper;
    private IBookReadOnlyRepository ReadOnlyRepository { get; } = readOnlyRepository;

    public async Task<GetBookByIdResponse> ExecuteAsync(int id)
    {
        var book = await ReadOnlyRepository.GetBookByIdAsync(id);

        if (book is null)
        {
            throw new Exception("Book not found.");
        }

        var bookDto = Mapper.DomainToResponse(book);

        return bookDto;
    }
}