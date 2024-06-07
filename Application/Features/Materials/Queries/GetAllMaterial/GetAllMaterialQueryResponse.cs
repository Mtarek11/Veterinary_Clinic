using Domain.Entities;

namespace Application.Features.Materials.Queries.GetAllMateria;

public record GetAllMaterialQueryResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}


