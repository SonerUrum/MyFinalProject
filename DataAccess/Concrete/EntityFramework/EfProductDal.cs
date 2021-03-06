using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDTo> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {   // sql'in linq'de karşılığıdır. Ürünler tablosunu kategori tablosuyla CategoryId'si aynı olanlarla join et 
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDTo 
                             {ProductId = p.ProductId, ProductName = p.ProductName, 
                                 CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock
                             };
                return result.ToList(); 
            }
        }
    }
}
