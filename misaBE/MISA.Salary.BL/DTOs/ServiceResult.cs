namespace MISA.Salary.BL.DTOs;

public class ServiceResult<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = [];

    public static ServiceResult<T> Ok(T data, string? message = null) =>
        new() { Success = true, Data = data, Message = message };

    public static ServiceResult<T> Fail(string error) =>
        new() { Success = false, Errors = [error] };

    public static ServiceResult<T> Fail(List<string> errors) =>
        new() { Success = false, Errors = errors };
}

public class PagedResult<T>
{
    public IEnumerable<T> Data { get; set; } = [];
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
