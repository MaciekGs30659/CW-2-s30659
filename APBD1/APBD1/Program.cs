using APBD1;

LiquidContainer lc1 = new LiquidContainer(0, 200, 120, 100, 2000, true);
lc1.Load(2000);
lc1.Load(800);
Console.WriteLine(lc1);

GasContainer gc1 = new GasContainer(500, 300, 300, 200, 1000, 8);
gc1.Unload();
Console.WriteLine(gc1);

// RefrigeratedContainer rc1 = new RefrigeratedContainer(1000, 300, 1000, 200, 10000, "Bananas", 10); zwraca wyjątek
RefrigeratedContainer rc1 = new RefrigeratedContainer(1000, 300, 1000, 200,
    10000, "Bananas", 14);
Console.WriteLine(rc1);

List<Container> containers = new List<Container>();
containers.Add(lc1);
containers.Add(gc1);

ContainerShip cs1 = new ContainerShip(25, 10, 30);
cs1.AddContainers(containers);
cs1.AddContainer(rc1);
Console.WriteLine(cs1);
cs1.RemoveContainer(gc1);
Console.WriteLine(cs1);

ContainerShip cs2 = new ContainerShip(20, 15, 50);
ContainerShip.TransferContainer(cs1, cs2, rc1);
Console.WriteLine(cs2);





