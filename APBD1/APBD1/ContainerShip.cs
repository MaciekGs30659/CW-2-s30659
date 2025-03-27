namespace APBD1;

public class ContainerShip
{
    public double maxSpeed { get; set; }
    public int maxCapacity { get; set; }
    public double maxWeight { get; set; }
    
    private List<Container> _containers;

    public ContainerShip(double maxSpeed, int maxCapacity, double maxWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxCapacity = maxCapacity;
        this.maxWeight = maxWeight*1000;
        _containers = new List<Container>();
    }

    public void AddContainer(Container container)
    {
        _containers.Add(container);
        if (_containers.Count > maxCapacity)
            throw new Exception($"Ship at max capacity{_containers.Count}/{maxCapacity}");
        if (CurrentWeight() > maxWeight)
            throw new Exception($"Ship to heavy{CurrentWeight()}/{maxWeight}");
    }

    public void AddContainers(List<Container> containers)
    {
        _containers.AddRange(containers);
        if (_containers.Count > maxCapacity)
            throw new Exception($"Ship at max capacity{_containers.Count}/{maxCapacity}");
        if (CurrentWeight() > maxWeight)
            throw new Exception($"Ship to heavy{CurrentWeight()}/{maxWeight}");
    }

    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }

    public static void TransferContainer(ContainerShip from, ContainerShip to, Container container)
    {
        to.AddContainer(container);
        from.RemoveContainer(container);
    }

    private double CurrentWeight()
    {
        double weight = 0;
        foreach(Container c in _containers)
            weight += c.LoadWeight + c.SoleWeight;
        
        return weight;
    }
    

    public override string ToString()
    {
        string s =
            ($"Max Speed: {maxSpeed}kn\n" +
             $"Capacity: {_containers.Count}/{maxCapacity}\n" +
             $"Weight: {CurrentWeight()}/{maxWeight}\n" +
             $"Containers:\n");
        

        foreach (Container c in _containers)
            s += c.serialNumber + "\n";

        return s;
    }
    
}