using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCConsoleApp1
{
    public  interface IPizza
    {
        string GetPizza();
    }
    public class  Veg : IPizza 
    {
        public string GetPizza()
        {
            return "veg pizza";
        }
    }
    public class NonVeg : IPizza
    {
        public string GetPizza()
        {
            return "Non-Veg pizza";
        }
    }

    public interface PizzaFactory
    {
        IPizza prepare();

    }

    public class VegPizzaFactory : PizzaFactory
    {
        public IPizza prepare()
        {
            return new Veg();
        }
    }
    public class NonVegPizzaFactory : PizzaFactory
    {
        public IPizza prepare()
        {
            return new NonVeg();
        }
    }

    public class PizzaStore
    {
        private PizzaFactory _factory;
        public PizzaStore(PizzaFactory factory)
        {
            _factory = factory;
        }
        public string OrderPizza()
        {
            IPizza pizza = _factory.prepare();
            return pizza.GetPizza();
        }
    }

    public class PizzaStoreClient
    {
        public void Main()
        {
            PizzaFactory factory = new VegPizzaFactory();
            PizzaStore store = new PizzaStore(factory);
            Console.WriteLine(store.OrderPizza());
        }
    }
    
}
