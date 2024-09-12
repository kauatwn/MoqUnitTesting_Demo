using Application.DTOs.Requests.Book;
using Application.DTOs.Responses.Book;

namespace Application.Abstractions.UseCases.Book;

public interface IGetBookByIdUseCase
{
    Task<GetBookByIdResponse> ExecuteAsync(GetBookByIdRequest id);
}