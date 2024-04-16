using CsvHelper.Configuration.Attributes;

public class TodoDolarGetDTO
{
    [Name("Currency_Base")]
    public string? Currency_Base { get; set; }

    [Name("Currency_Quote")]
    public string? Currency_Quote { get; set; }

    [Name("Ratio")]
    public decimal? Ratio { get; set; }

    [Name("Rate")]
    public decimal? Rate { get; set; }

    [Name("Inv_Rate")]
    public string? Inv_Rate { get; set; }

    [Name("Creation_Date")]
    public DateTime? Creation_Date { get; set; }

    [Name("Valid_Until")]
    public DateTime? Valid_Until { get; set; }
}
