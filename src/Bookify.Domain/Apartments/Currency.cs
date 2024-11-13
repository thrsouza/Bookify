namespace Bookify.Domain.Apartments;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency Brl = new("BRL");
    
    private Currency(string code) => Code = code;
    public string Code { get; init; }
    
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) 
               ?? throw new ApplicationException("The currency code is invalid");
    }
    
    public static readonly IReadOnlyCollection<Currency> All = [Usd, Eur, Brl];
}