namespace APBD1;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }
    
    public LiquidContainer(double loadWeight, double height, double soleWeight, double depth, double maxWeight,
        bool isHazardous) : base(loadWeight, height, soleWeight, depth, maxWeight, 'L')
    {
        IsHazardous = isHazardous;
    }

    public void Load(double weight)
    {
        double allowed = IsHazardous ? MaxWeight * 0.5 : MaxWeight * 0.9;

        if (weight > allowed)
            NotifyHazard($"Attempt of hazardous operation: {serialNumber}");
        else 
            base.Load(weight);
    }

    public void NotifyHazard(string message)
    {
        Console.Error.WriteLine($"{message}\n");
    }
}