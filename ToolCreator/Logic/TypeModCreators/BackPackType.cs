using System;
using System.IO;
using System.Text;
using System.Globalization;

//Gorney-Alex program

public class BackPackType : ICanBeCreated
{
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Backpack");
            writer.WriteLine("Rarity {0}");
            writer.WriteLine("Useable Clothing");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X");
            writer.WriteLine("Size_Y");
            writer.WriteLine("Size_Z");
            writer.WriteLine();
            writer.WriteLine("Width");
            writer.WriteLine("Height");
            writer.WriteLine();
        }
    }
}