using System;
using System.IO;
using System.Text;

//Gorney-Alex program

public class HatType : ICanBeCreated
{
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Hat");
            writer.WriteLine("Rarity Common");
            writer.WriteLine("Useable Clothing");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X 2");
            writer.WriteLine("Size_Y 2");
            writer.WriteLine("Size_Z 0.5");
            writer.WriteLine();
            writer.WriteLine("Armor 0.9");
        }
    }
}