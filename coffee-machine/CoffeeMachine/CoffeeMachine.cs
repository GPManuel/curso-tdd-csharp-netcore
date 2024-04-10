namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        private readonly DrinkMaker _drinkMaker;
        private Order order;

        public CoffeeMachine(DrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
            order = new EmptyOrder();
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
            order = order.ResetOrder();
        }
    }

    public enum DrinkType
    {
        None,
        Coffee = 'C',
        Tea = 'T',
        Chocolate = 'H'
    }
}