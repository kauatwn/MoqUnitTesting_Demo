namespace Domain.Interfaces.Repositories.Book;

public interface IBookReadOnlyRepository
{
    Task<Entities.Book?> GetBookByIdAsync(int id);
}