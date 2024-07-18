namespace App.Domain.Core.OrderAgg.Entities
{
    public enum Status
    {
        Pending = 1,
        InProgress = 2,
        Completed = 3,
        accepted = 4,
        WaitingForCustomer = 5,
        unAccepted = 6,
    }
}
