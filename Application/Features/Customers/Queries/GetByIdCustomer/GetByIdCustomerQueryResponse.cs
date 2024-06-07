namespace Application.Features.Customers.Queries.GetByIdCustomer
{

    public record GetByIdCustomerQueryResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }

}