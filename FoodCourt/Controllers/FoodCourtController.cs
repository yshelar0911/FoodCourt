using FC.BAL.InterfaceBAL;
using FC.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodCourt.Controllers
{

    [ApiController]
    [Route("FoodCourt/GetCategory")]
   
    public class FoodCourtController:Controller
    {
        public IFCBusiness fCBusiness;

        public FoodCourtController(IFCBusiness fCBusiness)
        {
            this.fCBusiness = fCBusiness;
        }
        
        [HttpGet(Name = "GetCategory")]
        public IEnumerable<Category> GetCategory()
        {
            var a = fCBusiness.Category();
            return a;
        }
    }
}
