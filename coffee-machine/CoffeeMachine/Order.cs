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

    internal void ResetOrder()
    {
        ResetSugar();
    }

    internal string ComposeCommand()
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

    private void ResetSugar()
    {
        numberOfSugars = 0;
    }
}