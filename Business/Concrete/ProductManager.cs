using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public List<Product> Getall()
        {
            //iş kodları yetkisi var mı
            return _ProductDal.GetAll();
        }
        
        public List<Product> GetAllByCategoryId(int id)
        {
            return _ProductDal.GetAll(p => p.CategoryId == id);
        }
       
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _ProductDal.GetAll(p => p.Unitprice >= min && p.Unitprice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _ProductDal.GetProductDetails();
        }
    }
}
