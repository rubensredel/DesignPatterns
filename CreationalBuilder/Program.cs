namespace CreationalBuilder;

interface IPizza
{
    PizzaType Type { get; }
    PizzaSize Size { get; }
    PizzaCrust Crust { get; }
    PizzaSauce Sauce { get; }
    PizzaTopping[] Toppings { get; }
}

enum PizzaType
{
    Cheese,
    Pepperoni,
    Hawaiian,
    Veggie
}

enum PizzaSize
{
    Small,
    Medium,
    Large
}

enum PizzaCrust
{
    Thin,
    Thick
}

enum PizzaSauce
{
    Tomato,
    White
}

enum PizzaTopping
{
    Cheese,
    Pepperoni,
    Ham,
    Pineapple,
    Mushroom,
    Onion,
    GreenPepper
}

class Pizza (PizzaType type, PizzaSize size, PizzaCrust crust, PizzaSauce sauce, PizzaTopping[] toppings) : IPizza
{
    public PizzaType Type { get; } = type;
    public PizzaSize Size { get; } = size;
    public PizzaCrust Crust { get; } = crust;
    public PizzaSauce Sauce { get; } = sauce;
    public PizzaTopping[] Toppings { get; } = toppings;
    public override string ToString()
    {
        return $"--------------Pizza--------------\r\n\tType: {Type}\r\n\tSize: {Size}\r\n\tCrust: {Crust}\r\n\tSauce: {Sauce}\r\n\tToppings: \r\n\t\t{string.Join("\r\n\t\t", Toppings)}";
    }
}

interface IPizzaBuilder
{
    IPizzaBuilder SetType(PizzaType type);
    IPizzaBuilder SetSize(PizzaSize size);
    IPizzaBuilder SetCrust(PizzaCrust crust);
    IPizzaBuilder SetSauce(PizzaSauce sauce);
    IPizzaBuilder AddTopping(PizzaTopping topping);
    IPizza Build();
}

class PizzaBuilder : IPizzaBuilder
{
    private PizzaType _type;
    private PizzaSize _size;
    private PizzaCrust _crust;
    private PizzaSauce _sauce;
    private readonly List<PizzaTopping> _toppings = [];
    public IPizzaBuilder SetType(PizzaType type) { _type = type; return this; }
    public IPizzaBuilder SetSize(PizzaSize size) { _size = size; return this; }
    public IPizzaBuilder SetCrust(PizzaCrust crust) { _crust = crust; return this; }
    public IPizzaBuilder SetSauce(PizzaSauce sauce) { _sauce = sauce; return this; }
    public IPizzaBuilder AddTopping(PizzaTopping topping) { _toppings.Add(topping); return this; }
    public IPizza Build() => new Pizza(_type, _size, _crust, _sauce, [.. _toppings]);
}

internal class Program
{
    static void Main(string[] args)
    {
        PizzaBuilder builder = new();
        IPizza pizza = builder
            .SetType(PizzaType.Pepperoni)
            .SetSize(PizzaSize.Large)
            .SetCrust(PizzaCrust.Thin)
            .SetSauce(PizzaSauce.Tomato)
            .AddTopping(PizzaTopping.Cheese)
            .AddTopping(PizzaTopping.Ham)
            .AddTopping(PizzaTopping.Pineapple)
            .AddTopping(PizzaTopping.Pepperoni)
            .Build();
        Console.WriteLine(pizza);
    }
}
