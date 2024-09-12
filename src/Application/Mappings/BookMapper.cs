using Application.Abstractions.Mappings;
using Application.DTOs.Responses.Book;
using Domain.Entities;

namespace Application.Mappings;

public class BookMapper : IBookMapper
{
    public GetBookByIdResponse DomainToResponse(Book book)
    {
        return new GetBookByIdResponse(book.Id, book.Title, book.Author);
    }
}