using System;
using System.Collections.Generic;

namespace Design_Patterns
{
    internal class Program
    {
        class Meal
        {
            private string _mealType;
            private Dictionary<string, string> _items = new Dictionary<string, string>();

            public Meal(string mealType)
            {
                _mealType = mealType;
            }

            public string this[string key]
            {
                get { return _items[key]; }
                set { _items[key] = value; }
            }

            public void Show()
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Meal type: \t{0}", _mealType);
                Console.WriteLine("Burger\t : \t{0} ", _items["burger"]);
                Console.WriteLine("Drink\t : \t{0} ", _items["drink"]);
                Console.WriteLine("Dessert\t : \t{0} ", _items["dessert"]);
                Console.WriteLine("Toy\t : \t{0} ", _items["toy"]);
            }
        }


        abstract class MealBuilder
        {
            protected Meal meal;

            public Meal Meal { get { return meal; } }

            public abstract void BuildBurger();
            public abstract void BuildDrink();
            public abstract void BuildDessert();
            public abstract void BuildToy();
        }

        class HappyMealBuilder : MealBuilder
        {
            public HappyMealBuilder()
            {
                meal = new Meal("Happy Meal");
            }

            public override void BuildBurger()
            {
                meal["burger"] = "Cheeseburger";
            }

            public override void BuildDrink()
            {
                meal["drink"] = "Small Coke";
            }

            public override void BuildDessert()
            {
                meal["dessert"] = "Apple Pie";
            }

            public override void BuildToy()
            {
                meal["toy"] = "Toy A";
            }
        }

        class KidsMealBuilder : MealBuilder
        {
            public KidsMealBuilder()
            {
                meal = new Meal("Kids Meal");
            }

            public override void BuildBurger()
            {
                meal["burger"] = "Chicken Double Patty";
            }

            public override void BuildDrink()
            {
                meal["drink"] = "Apple Juice";
            }

            public override void BuildDessert()
            {
                meal["dessert"] = "Ice Cream Cone";
            }

            public override void BuildToy()
            {
                meal["toy"] = "Toy B";
            }
        }

        class FancyMealBuilder : MealBuilder
        {
            public FancyMealBuilder()
            {
                meal = new Meal("Fancy Meal");
            }

            public override void BuildBurger()
            {
                meal["burger"] = "Gourmet Burger";
            }

            public override void BuildDrink()
            {
                meal["drink"] = "Sparkling Water";
            }

            public override void BuildDessert()
            {
                meal["dessert"] = "Chocolate Fondue";
            }

            public override void BuildToy()
            {
                meal["toy"] = "Toy C";
            }
        }

        class MealShop
        {
            public void Construct(MealBuilder mealBuilder)
            {
                mealBuilder.BuildBurger();
                mealBuilder.BuildDrink();
                mealBuilder.BuildDessert();
                mealBuilder.BuildToy();
            }
        }

        static void Main(string[] args)
        {
            MealBuilder builder;

            MealShop mealShop = new MealShop();

            builder = new HappyMealBuilder();
            mealShop.Construct(builder);
            builder.Meal.Show();

            builder = new KidsMealBuilder();
            mealShop.Construct(builder);
            builder.Meal.Show();

            builder = new FancyMealBuilder();
            mealShop.Construct(builder);
            builder.Meal.Show();

            Console.ReadKey();
        }
    }
}
