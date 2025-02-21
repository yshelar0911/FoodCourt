using FC.BAL.InterfaceBAL;
using FC.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodCourt.Controllers
{

    [ApiController]
    [Route("FoodCourt")]
   
    public class FoodCourtController:Controller
    {
        public IFCBusiness fCBusiness;

        public FoodCourtController(IFCBusiness fCBusiness)
        {
            this.fCBusiness = fCBusiness;
        }
        
        [HttpGet, Route("GetCategory")]
        public IEnumerable<Category> GetCategory()
        {
            var a = fCBusiness.Category();
            return a;
        }

        [HttpGet,Route("GetProductsOnCategoryId")]
        public IEnumerable<Product> GetProductsOnCategoryId(byte categoryId)
        {
            var a = fCBusiness.GetProductsOnCategoryId(categoryId);
            return a;
        }
    }
}
