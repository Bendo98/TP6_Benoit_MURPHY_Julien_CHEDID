using System;
using System.Collections.Generic;

namespace TP6pizza
{
    public class Program
    {
        public static void Main()
        {
            PizzaBuilder builder;
            Restaurant rest = new Restaurant();
            builder = new TomatoBuilder();
            rest.Construct(builder);
            builder.Pizza.Show();
            builder = new FreshCreamBuilder();
            rest.Construct(builder);
            builder.Pizza.Show();
            Console.ReadKey();
        }
    }
    class Restaurant
    {
       
        public void Construct(PizzaBuilder pizzaBuilder)
        {
            pizzaBuilder.BuildBase();
            pizzaBuilder.BuildTopping1();
            pizzaBuilder.BuildTopping2();
            pizzaBuilder.BuildTopping3();
        }
    }
    
    abstract class PizzaBuilder
    {
        protected Pizza pizza;
        public Pizza Pizza
        {
            get { return pizza; }
        }
        public abstract void BuildBase();
        public abstract void BuildTopping1();
        public abstract void BuildTopping2();
        public abstract void BuildTopping3();
    }
    
    class FreshCreamBuilder : PizzaBuilder
    {
        public FreshCreamBuilder()
        {
            pizza = new Pizza("Milano");
        }
        public override void BuildBase()
        { 
            pizza["base"] = "fresh cream + mozzarella";
        }
        public override void BuildTopping1()
        {
            pizza["topp1"] = "potatoes";
        }
        public override void BuildTopping2()
        {
            pizza["topp2"] = "bacon";
        }
        public override void BuildTopping3()
        {
            pizza["topp3"] = "eggs";
        }
    }
    
    class TomatoBuilder : PizzaBuilder
    {
        public TomatoBuilder()
        {
            pizza = new Pizza("Regina");
        }
        public override void BuildBase()
        {
            pizza["base"] = "tomatoes + mozzarella";
        }
        public override void BuildTopping1()
        {
            pizza["topp1"] = "mushroom";
        }
        public override void BuildTopping2()
        {
            pizza["topp2"] = "ham";
        }
        public override void BuildTopping3()
        {
            pizza["topp3"] = "olive";
        }
    }
    
    class Pizza
    {
        private string _pizzaType;
        private Dictionary<string, string> _parts =
            new Dictionary<string, string>();
        public Pizza(string pizzaType)
        {
            this._pizzaType = pizzaType;
        }
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Pizza type: {0}", _pizzaType);
            Console.WriteLine(" Base : {0}", _parts["base"]);
            Console.WriteLine(" Topp1 : {0}", _parts["topp1"]);
            Console.WriteLine(" Topp2 : {0}", _parts["topp2"]);
            Console.WriteLine(" Topp3 : {0}", _parts["topp3"]);
        }
    }
    
}