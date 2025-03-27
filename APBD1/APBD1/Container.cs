namespace APBD1;

public class Container
{
    private static int _counter = 1;
    public double LoadWeight{ get; set; }
    public double Height{ get; set; }
    public double SoleWeight { get; set; }
    public double Depth { get; set; }
    public double MaxWeight { get; set; }
    public string serialNumber { get; set; }

    public Container(double loadWeight, double height, double soleWeight, double depth, double maxWeight, char type)
    {
        LoadWeight = loadWeight;
        Height = height;
        SoleWeight = soleWeight;
        Depth = depth;
        MaxWeight = maxWeight;
        
        serialNumber = $"KON-{type}-{_counter++}";
    }

    public void Load(double weight)
    {
        if (LoadWeight + weight > MaxWeight)
            throw new OverflowException("Load is too big"); 
        
        LoadWeight += weight;
    }

    public void Unload()
    {
        LoadWeight = 0;
    }

    public override string ToString()
    {
        return (
            $"Container: {serialNumber}\nSole weight: {SoleWeight} kg\nCargo Weight: {LoadWeight}/{MaxWeight} kg\n" +
            $"Dimensions: {Height}cmx{Depth}cm\n");
    }
    
}