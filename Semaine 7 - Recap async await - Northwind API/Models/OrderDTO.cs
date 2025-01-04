namespace Semaine_7___Recap_async_await___Northwind_API.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string? CustomerId { get; set; }
        public int? EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}
