using AEBestGatePath.Data.Auth.Context;
using AEBestGatePath.Data.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API.Auth.Services;

public interface IUserService
{
    public Task<User> CreateAsync(CreateUserCommand userDto, CancellationToken cancellationToken = default);
    public Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);
    public Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default);
    public Task<User?> GetByExternalIdAsync(string externalId, CancellationToken cancellationToken = default);
    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

internal class UserService(AuthContext dbContext) : IUserService
{
    public async Task<User> CreateAsync(CreateUserCommand request, CancellationToken cancellationToken = default)
    {
        var user = new User
        {
            ExternalId = request.ExternalId,
            Username = request.Username,
            Email = request.Email,
            ProfilePicture = request.ProfilePicture,
            SignInCount = 1
        };

        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is not null) dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.Include(x => x.UserRoles)
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

        return user;
    }

    public async Task<User?> GetByExternalIdAsync(string externalId, CancellationToken cancellationToken = default)
    {
        var user = await dbContext.Users.Include(x => x.UserRoles)
            .FirstOrDefaultAsync(u => u.ExternalId == externalId, cancellationToken);

        return user;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await dbContext.Users.Include(x => x.UserRoles)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        return user;
    }
}