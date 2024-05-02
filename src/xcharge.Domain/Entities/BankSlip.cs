using xcharge.Domain.Entities.Base;

namespace xcharge.Domain.Entities;

public sealed class BankSlip : BaseEntity
{
    public AppUser? User { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public double Amount { get; private set; }
    public int Interest { get; private set; }
    public int FixedInterest { get; private set; }
    public int Fine { get; private set; }
    public double Discount { get; private set; }
    public double Discount2 { get; private set; }
    public double Discount3 { get; private set; }
    public int DiscountDays1 { get; private set; }
    public int DiscountDays2 { get; private set; }
    public int DiscountDays3 { get; private set; }
    public bool IsBankSlipUpdated { get; private set; }
}
