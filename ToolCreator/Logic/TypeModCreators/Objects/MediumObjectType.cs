using System;
using System.IO;
using System.Text;

//Gorney-Alex program

public class MediumObjectType : ICanBeCreated
{
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Medium");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Has_Clip_Prefab false");
        }
    }
}