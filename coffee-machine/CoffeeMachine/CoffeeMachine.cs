namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        private readonly DrinkMaker _drinkMaker;
        private Order order;

        public CoffeeMachine(DrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
        }

        public void SelectCoffee()
        {
            order = new Order(DrinkType.Coffee);
        }

        public void SelectChocolate()
        {
            order = new Order(DrinkType.Chocolate);
        }


        public void SelectTea()
        {
            order = new Order(DrinkType.Tea);
        }

        public void AddOneSpoonOfSugar()
        {
            order.AddOneSpoonOfSugar();
        }

        public void MakeDrink()
        {
            var command = order.ComposeCommand();
            _drinkMaker.Execute(command);
            order.ResetOrder();
        }
    }

    public enum DrinkType
    {
        Coffee = 'C',
        Tea = 'T',
        Chocolate = 'H'
    }
}