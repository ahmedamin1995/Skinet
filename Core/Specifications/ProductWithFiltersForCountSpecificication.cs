
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
   public class ProductWithFiltersForCountSpecificication : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecificication(ProductSpecParams productSpecParams )
            :base(x => (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
           && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
            && (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId))
        {
                
        }
    }
}
