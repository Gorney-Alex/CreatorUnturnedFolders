using System;
using System.IO;
using System.Text;
using System.Globalization;

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
    
    public BarricadeType(int x, int y, float z, int health, float range, float radius, float offset, int explosion, string rarity, bool isForMasterBundle)
    {
        _x = x;
        _y = y;
        _z = z;
        _health = health;
        _range = range;
        _radius = radius;
        _rarity = rarity;
        _offset = offset;
        _explosion = explosion;
        _isForMasterBundle = isForMasterBundle;
    }
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
            writer.WriteLine("Size_X {0}", _x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", _y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", _z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Health {0}", _health.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Range {0}", _range.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Radius {0}", _radius.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Offset {0}", _offset.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Explosion {0}", _explosion.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Has_Clip_Prefab false");
            writer.WriteLine();
            writer.WriteLine("Procedurally_Animate_Inertia false");
            if (_isForMasterBundle)
            {
                writer.WriteLine();
            }
            else
            { 
                writer.WriteLine("Exclude_From_Master_Bundle");
            }
        }
    }
}
