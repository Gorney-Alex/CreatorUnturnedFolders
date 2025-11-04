using System;
using System.IO;
using System.Text;

//Gorney-Alex program

public class WaterType : ICanBeCreated
{
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Water");
            writer.WriteLine("Rarity Common");
            writer.WriteLine("Useable Consumeable");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X 1");
            writer.WriteLine("Size_Y 1");
            writer.WriteLine("Size_Z 0.5");
            writer.WriteLine();
            writer.WriteLine("Food 5");
            writer.WriteLine("Water 15");
        }
    }
}