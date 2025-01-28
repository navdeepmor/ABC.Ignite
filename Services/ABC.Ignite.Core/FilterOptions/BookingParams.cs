namespace ABC.Ignite.Core.FilterOptions;

public class BookingParams : QueryParams
{
    private string? searchTerm;

    public string? SearchTerm
    {
        get => this.searchTerm;
        set => this.searchTerm = !string.IsNullOrWhiteSpace(value) ? value.Trim().ToLowerInvariant() : null;
    }

    public DateOnly? StartDate { get; set; }
    
    public DateOnly? EndDate { get; set; }
}
