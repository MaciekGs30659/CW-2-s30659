namespace APBD1;

public class GasContainer : Container, IHazardNotifier
{
    private double _maxPressure = 10;
    public double Pressure { get; set; }
    
    public GasContainer(double loadWeight, double height, double soleWeight, double depth, double maxWeight, 
        double pressure) : base(loadWeight, height, soleWeight, depth, maxWeight, 'G')
    {
        Pressure = pressure;
        if (pressure > _maxPressure)
            NotifyHazard("The pressure is too high");
    }

    public void Unload()
    {
        LoadWeight *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.Error.WriteLine($"{message}\n");
    }
}