using System;
using System.IO;
using System.Text;
using System.Globalization;

//Gorney-Alex program

public class BarricadeType : ICanBeCreated
{
    private int _x;
    private int _y;
    private float _z;
    private int _health;
    private float _range;
    private float _radius;
    private string _rarity;
    private float _offset;
    private int _explosion;
    private bool _isForMasterBundle;
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Barricade");
            writer.WriteLine("Rarity {0}", _rarity);
            writer.WriteLine("Useable Barricade");
            writer.WriteLine("Build Campfire");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X");
            writer.WriteLine("Size_Y");
            writer.WriteLine("Size_Z");
            writer.WriteLine();
            writer.WriteLine("Health");
            writer.WriteLine("Range");
            writer.WriteLine("Radius");
            writer.WriteLine("Offset");
            writer.WriteLine();
            writer.WriteLine("Explosion");
            writer.WriteLine();
            writer.WriteLine("Has_Clip_Prefab false");
            writer.WriteLine();
            writer.WriteLine("Procedurally_Animate_Inertia false");
        }
    }
}
