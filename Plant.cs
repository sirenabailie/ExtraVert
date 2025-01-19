public class Plant
{
    public required string Species { get; set; }
    public int LightNeeds { get; set; } // Scale of 1-5 (shade to full sun)
    public decimal AskingPrice { get; set; }
    public required string City { get; set; }
    public int ZIP { get; set; }
    public bool Sold { get; set; }
    public  DateTime AvailableUntil { get; set; }
}
