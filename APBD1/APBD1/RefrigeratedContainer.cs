namespace APBD1;

public class RefrigeratedContainer : Container
{
    private static Dictionary<string, double> _temperatures = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };
    
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    
    public RefrigeratedContainer(double loadWeight, double height, double soleWeight, double depth, double maxWeight, 
        string productType, double temperature) : base(loadWeight, height, soleWeight, depth, maxWeight, 'C')
    {
        double requiredTemp = 10.0;
        if (_temperatures.ContainsKey(productType))
             requiredTemp = _temperatures[productType];

        if (requiredTemp > temperature)
            throw new InvalidOperationException(
                $"Temperature {temperature}°C is too low for {productType} (minimum {requiredTemp}°C required)");
        
        ProductType = productType;
        Temperature = temperature;
    }
}