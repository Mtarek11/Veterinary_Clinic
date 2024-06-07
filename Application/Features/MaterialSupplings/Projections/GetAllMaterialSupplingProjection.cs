using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Projections
{
    public static class GetAllMaterialSupplingProjection
    {
        public static Expression<Func<MaterialSuppling, MaterialSuppling>> ToGetAllMaterialSupplingProjection()
        {
            return m => new MaterialSuppling()
            {
                SupplyCount = m.SupplyCount,
                SupplyDate = m.SupplyDate,
                SupplyPrice = m.SupplyPrice,
                CreatedOn = m.CreatedOn,
                LastModifiedOn = m.LastModifiedOn,
                Id = m.Id,
                Material = new Material()
                {
                    Name = m.Material.Name,
                },
            };
        }
    }
}
