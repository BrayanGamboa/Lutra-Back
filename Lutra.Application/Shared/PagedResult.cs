namespace Lutra.Application.Shared;

public record PagedResult<T>(IEnumerable<T> Data, int Total, int Page, int PageSize);
