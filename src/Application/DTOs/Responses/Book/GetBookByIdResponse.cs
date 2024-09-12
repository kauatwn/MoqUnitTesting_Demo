namespace Application.DTOs.Responses.Book;

public record GetBookByIdResponse(int Id, string Title, string Author);