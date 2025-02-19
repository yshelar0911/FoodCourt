using FC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FC.DAL.Repositary
{
    public class FoodCourtRepo
    {
        public QuickKartDbContext QuickKartDbContext { get; set; }
        public FoodCourtRepo(QuickKartDbContext quickKartDbContext)
        {
            this.QuickKartDbContext = quickKartDbContext;
        }


    }
}
