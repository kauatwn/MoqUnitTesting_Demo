using Application.DTOs.Responses.Book;
using Domain.Entities;

namespace Application.Abstractions.Mappings;

public interface IBookMapper
{
    GetBookByIdResponse DomainToResponse(Book book);
}