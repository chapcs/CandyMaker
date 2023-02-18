// using CandyMaker;
using System.Security.Cryptography.X509Certificates;


internal class CandyMaker
{
    private static void Main(string[] args)
    {
        while (true)
        {
            TemperatureChecker temperatureChecker = new TemperatureChecker();
            temperatureChecker.ThreeMinuteCheck();
            Thread.Sleep(6000);
        }
    }
}
internal class TemperatureChecker
{
    Maker maker = new Maker();
    IsolationCoolingSystem isolation = new IsolationCoolingSystem();
    TurbineController turbines = new TurbineController();

    /// <summary>
    /// If the nougat temperature exceeds 160C it's too hot
    /// </summary>
    public bool IsNougatTooHot()
    {
        int temp = maker.CheckNougatTemperature();
        if (temp > 160)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Perform the Candy Isolation Cooling System vent procedure
    /// </summary>
    public void DoCICSVentProcedure()
    {
        turbines.CloseTripValve(2);
        isolation.Fill();
        isolation.Vent();
        maker.CheckAirSystem();
    }
    /// <summary>
    /// This code runs every 3 minutes (10sec) to check the temperature.
    /// If it exceeds 160c we need to vent the cooling system.
    /// </summary>
    public void ThreeMinuteCheck()
    {
        if (IsNougatTooHot() == true)
            DoCICSVentProcedure();
        else
            Console.WriteLine("Nougat is still at or below 160 C\n");
    }
}

internal class TurbineController
{
    // method CloseTripValve with multiple valves 1-4 to close
    public void CloseTripValve(int valve)
    {
        Console.WriteLine("Closing trip valve #" + valve);
        Thread.Sleep(2000);
    }
}

internal class IsolationCoolingSystem
{
    // two methods fill and vent that don't return anything
    public void Fill()
    {
        Console.Write("Filling ICS : ");
        Thread.Sleep(2000);
    }
    public void Vent()
    {
        Console.WriteLine("Venting ICS");
        Thread.Sleep(2000);
    }
}

internal class Maker
{
    Random random = new Random();

    public int CheckNougatTemperature()
    {
        int randomTemp = random.Next(155, 170 + 1);
        Console.WriteLine("Nougat temperature: " + randomTemp + " C");
        return randomTemp;
    }
    public void CheckAirSystem()
    {
        bool air = random.Next(2) == 0;
        Console.WriteLine("Checking for air in system . . .");
        Thread.Sleep(2000);
        if (air == true)
            Console.WriteLine("Air present in system\n");
        else
            Console.WriteLine("10 m3 air added to system\n");
    }
}