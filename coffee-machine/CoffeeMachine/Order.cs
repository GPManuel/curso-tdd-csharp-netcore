namespace CoffeeMachine;

internal class Order(DrinkType drinkType)
{
    private int numberOfSugars;

    internal void AddOneSpoonOfSugar()
    {
        if (numberOfSugars < 2)
        {
            numberOfSugars += 1;
        }
    }

    internal Order ResetOrder()
    {
        return new EmptyOrder();
    }

    internal virtual string ComposeCommand()
    {
        return (char)drinkType + ComposeCommandSugarSection();
    }

    private string ComposeCommandSugarSection()
    {
        if (numberOfSugars.Equals(0))
        {
            return "::";
        }
        return ":" + numberOfSugars + ":0";
    }
}

internal class EmptyOrder() : Order(DrinkType.None)
{
    internal override string ComposeCommand()
    {
        return "M:Please,select a drink";
    }
}