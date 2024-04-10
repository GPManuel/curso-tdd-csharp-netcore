using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTest
    {
        private DrinkMaker drinkMaker;
        private CoffeeMachine coffeeMachine;

        [SetUp]
        public void Setup()
        {
            drinkMaker = Substitute.For<DrinkMaker>();
            coffeeMachine = new CoffeeMachine(drinkMaker);
        }

        [Test]
        public void order_one_coffee_without_sugar()
        {
            coffeeMachine.SelectCoffee();
            coffeeMachine.MakeDrink();

            drinkMaker.Received(1).Execute("C::");
        }

        [Test]
        public void order_one_chocolate_without_sugar()
        {
            coffeeMachine.SelectChocolate();
            coffeeMachine.MakeDrink();

            drinkMaker.Received(1).Execute("H::");
        }


        [Test]
        public void order_one_tea_without_sugar()
        {
            coffeeMachine.SelectTea();
            coffeeMachine.MakeDrink();

            drinkMaker.Received(1).Execute("T::");
        }

        [Test]
        public void order_one_coffee_with_one_sugar()
        {
            coffeeMachine.SelectCoffee();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.MakeDrink();

            drinkMaker.Received(1).Execute("C:1:0");
        }

        [Test]
        public void order_one_coffee_with_two_sugar()
        {
            coffeeMachine.SelectCoffee();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.MakeDrink();

            drinkMaker.Received(1).Execute("C:2:0");
        }

        [Test]
        public void order_one_coffee_with_more_than_two_sugar()
        {
            coffeeMachine.SelectCoffee();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.MakeDrink();

            drinkMaker.Received(1).Execute("C:2:0");
        }

        [Test]
        public void reset_sugar_after_drink_made()
        {
            coffeeMachine.SelectCoffee();
            coffeeMachine.AddOneSpoonOfSugar();
            coffeeMachine.MakeDrink();

            coffeeMachine.SelectChocolate();
            coffeeMachine.MakeDrink();

            drinkMaker.Received(1).Execute("H::");

        }

        //[Test]
        //public void order_drink_without_drink_selected()
        //{
        //    coffeeMachine.MakeDrink();

        //    drinkMaker.Received(1).Execute("M:Please,select a drink");
        //}

        //[Test]
        //public void reset_drink_after_drink_made()
        //{
        //    coffeeMachine.SelectCoffee();
        //    coffeeMachine.MakeDrink();

        //    coffeeMachine.MakeDrink();

        //    drinkMaker.Received(1).Execute("M:Please,select a drink");
        //}
    }
}