using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Projections
{
    public static class GetByIdMaterialProjection
    {
        public static Expression<Func<Material, Material>> ToGetByIdMaterialrojection()
        {
            return m => new Material()
            {
              Id = m.Id,
              CreatedOn = m.CreatedOn,
              IsDeleted = m.IsDeleted,
              Name = m.Name,
              LastModifiedOn = m.LastModifiedOn,
              MaterialSupplings = m.MaterialSupplings.Select(ms => new MaterialSuppling()
              {
                  Id = ms.Id,
                  SupplyCount = ms.SupplyCount,
                  SupplyDate = ms.SupplyDate,
                  SupplyPrice = ms.SupplyPrice,
                  CreatedOn = ms.CreatedOn,
                  LastModifiedOn = ms.LastModifiedOn,
              }).ToList(),
            };
        }
    }
}
