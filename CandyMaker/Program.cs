using CandyMaker;
using System.Security.Cryptography.X509Certificates;

internal class TemperatureChecker
{
    public bool air = false;// air system is not checked yet
    Maker maker = new Maker();
    /// <summary>
    /// If the nougat temperature exceeds 160C it's too hot
    /// </summary>
    public static bool IsNougatTooHot()
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
        TurbineController turbines = new TurbineController();
        turbines.CloseTripValve(2);
        IsolationCoolingSystem.Fill();
        IsolationCoolingSystem.Vent();
        maker.CheckAirSystem();
    }
    /// <summary>
    /// This code runs every 3 minutes to check the temperature.
    /// If it exceeds 160c we need to vent the cooling system.
    /// </summary>
    public void ThreeMinuteCheck()
    {
        if (IsNougatTooHot() == true)
        {
            DoCICSVentProcedure();
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("hello");
    }
}