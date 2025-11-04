using System;
using System.IO;
using System.Text;

//Gorney-Alex program

public class LargeObjectType : ICanBeCreated
{
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Large");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("LOD Mesh");
            writer.WriteLine("LOD_Center_Z -0.5");
            writer.WriteLine("LOD_Size_Z -1");
            writer.WriteLine();
            writer.WriteLine("Has_Clip_Prefab false");
        }
    }
}