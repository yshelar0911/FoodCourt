using FC.BAL.BAL;
using FC.BAL.InterfaceBAL;
using FC.DAL.Models;
using FC.DAL.Repositary;
using Microsoft.AspNetCore.Mvc;

namespace FoodCourt.Controllers
{

    [ApiController]
    [Route("FoodCourt")]

    public class FoodCourtController : Controller
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

        [HttpGet, Route("GetProductsOnCategoryId")]
        public IEnumerable<Product> GetProductsOnCategoryId(byte categoryId)
        {
            var a = fCBusiness.GetProductsOnCategoryId(categoryId);
            return a;
        }

        [HttpPost, Route("UserLogin")]

        public JsonResult UserLogin(string username, string password)
        {
            var a = fCBusiness.UserLogin(username, password);
            return Json(a);
        }

        [HttpPost, Route("NewLogin")]

        public bool NewLogin(string userName, string emailId, string password, char gender, DateOnly dateOfBirth, string address)
        {
            var a = fCBusiness.NewLogin(userName, emailId, password,gender, dateOfBirth, address);
            return a;
        }


    }
}
