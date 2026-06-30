using Lutra.Application.Auth.Ports;
using Lutra.Application.Shared;

namespace Lutra.Application.Auth.UseCases.User;

public class GetAllUsersUseCase(IUserRepository userRepository)
{
    public async Task<PagedResult<UserListItemResponse>> ExecuteAsync(
        string? search, string? rol, int page, int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var (items, total) = await userRepository.GetAllAsync(search, rol, page, pageSize);
        var data = items.Select(UserListItemResponse.FromDomain);
        return new PagedResult<UserListItemResponse>(data, total, page, pageSize);
    }
}
