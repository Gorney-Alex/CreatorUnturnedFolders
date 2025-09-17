using System;
using System.IO;
using System.Text;
using System.Globalization;

public class CloudType : ICanBeCreated
{
    private int _x;
    private int _y;
    private float _z;
    private float _gravity;
    private string _rarity;
    private bool _isForMasterBundle;
    
    public CloudType(int x, int y, float z, float gravity, string rarity, bool isForMasterBundle)
    {
        _x = x;
        _y = y;
        _z = z;
        _gravity = gravity;
        _rarity = rarity;
        _isForMasterBundle = isForMasterBundle;
    }
    
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Cloud");
            writer.WriteLine("Rarity {0}", _rarity);
            writer.WriteLine("Useable Cloud");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", _x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", _y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", _z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Gravity {0}", _gravity.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            if (!_isForMasterBundle) writer.WriteLine("Exclude_From_Master_Bundle");
        }
    }
}