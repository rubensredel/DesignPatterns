namespace CreationalPrototype;

public interface IGraphicElement
{
    IGraphicElement Clone();
    void Display();
}

public class Line(int x1, int y1, int x2, int y2) : IGraphicElement
{
    public int X1 { get; set; } = x1;
    public int Y1 { get; set; } = y1;
    public int X2 { get; set; } = x2;
    public int Y2 { get; set; } = y2;

    public IGraphicElement Clone()
        => (IGraphicElement)MemberwiseClone();
    
    public void Display()
        => Console.WriteLine($"Line: ({X1}, {Y1}) to ({X2}, {Y2})");
}

public class Rectangle(int x, int y, int width, int height) : IGraphicElement
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int Width { get; set; } = width;
    public int Height { get; set; } = height;

    public IGraphicElement Clone()
        => (IGraphicElement)MemberwiseClone();

    public void Display()
        => Console.WriteLine($"Rectangle: ({X}, {Y}), width: {Width}, height: {Height}");
}

public class GraphicTool
{
    private readonly List<IGraphicElement> _graphicElements = [];
    public void AddGraphicElement(IGraphicElement graphicElement)
        => _graphicElements.Add(graphicElement);

    public void DisplayGraphicElements()
    {
        foreach (IGraphicElement graphicElement in _graphicElements)
        {
            graphicElement.Display();
        }
    }
}

internal class Program
{
    private readonly static Line prototypeLine = new(10, 10, 100, 100);
    private readonly static Rectangle prototypeRectangle = new(200, 200, 50, 50);

    static void Main(string[] args)
    {
        var line1 = prototypeLine.Clone();
        var line2 = prototypeLine.Clone();
        line2.GetType().GetProperty("X1")!.SetValue(line2, 20);

        var rect1 = prototypeRectangle.Clone();
        var rect2 = prototypeRectangle.Clone();
        rect2.GetType().GetProperty("X")!.SetValue(rect2, 250);

        var graphicTool = new GraphicTool();
        graphicTool.AddGraphicElement(line1);
        graphicTool.AddGraphicElement(line2);
        graphicTool.AddGraphicElement(rect1);
        graphicTool.AddGraphicElement(rect2);
        graphicTool.DisplayGraphicElements();
    }
}
