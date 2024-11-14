namespace Bookify.Application.Bookings.GetBooking;

public sealed class BookingResponse
{
    public Guid  Id { get; set; }
    public Guid ApartmentId { get; set; }
    public Guid UserId { get; set; }
    public int Status { get; set; }
    public decimal PriceAmount { get; set; }
    public string PriceCurrency { get; set; } = default!;
    public decimal CleaningFeeAmount { get; set; }
    public string CleaningFeeCurrency { get; set; } = default!;
    public decimal AmenitiesUpChargeAmount { get; set; }
    public string AmenitiesUpChargeCurrency { get; set; } = default!;
    public decimal TotalPriceAmount { get; set; }
    public string TotalPriceCurrency { get; set; } = default!;
    public DateOnly DurationStart { get; set; }
    public DateOnly DurationEnd { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}