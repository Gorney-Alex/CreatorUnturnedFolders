using System;
using System.IO;
using System.Text;

//Gorney-Alex program

public class BarricadeType : ICanBeCreated
{
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Barricade");
            writer.WriteLine("Rarity Common");
            writer.WriteLine("Useable Barricade");
            writer.WriteLine("Build Campfire");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X 1");
            writer.WriteLine("Size_Y 1");
            writer.WriteLine("Size_Z 0.5");
            writer.WriteLine();
            writer.WriteLine("Health 200");
            writer.WriteLine("Range 4");
            writer.WriteLine("Radius 0.6");
            writer.WriteLine("Offset 0.7");
            writer.WriteLine();
            writer.WriteLine("Explosion 19");
            writer.WriteLine();
            writer.WriteLine("Has_Clip_Prefab false");
            writer.WriteLine();
            writer.WriteLine("Procedurally_Animate_Inertia false");
        }
    }
}
