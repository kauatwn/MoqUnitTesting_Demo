using Domain.Entities;
using Domain.Interfaces.Repositories.Book;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext dbContext) : IBookReadOnlyRepository
{
    private AppDbContext DbContext { get; } = dbContext;

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await DbContext.Books.AsNoTracking().FirstOrDefaultAsync(book => book.Id == id);
    }
}