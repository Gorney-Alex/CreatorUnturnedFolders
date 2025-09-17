using System;
using System.IO;
using System.Text;
using System.Globalization;

//Gorney-Alex program

public class BackPackType : ICanBeCreated
{
    private int _x;
    private int _y;
    private float _z;
    private int _width;
    private int _height;
    private string _rarity;
    private bool _isForMasterBundle;
    
    public BackPackType(int x, int y, float z, int width, int height, string rarity, bool isForMasterBundle)
    {
        _x = x;
        _y = y;
        _z = z;
        _width = width;
        _height = height;
        _rarity = rarity;
        _isForMasterBundle = isForMasterBundle;
    }
    
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Backpack");
            writer.WriteLine("Rarity {0}", _rarity);
            writer.WriteLine("Useable Clothing");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", _x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", _y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", _z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Width {0}", _width.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Height {0}", _height.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            if (!_isForMasterBundle) writer.WriteLine("Exclude_From_Master_Bundle");
        }
    }
}