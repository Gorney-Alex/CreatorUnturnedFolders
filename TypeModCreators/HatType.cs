using System;
using System.IO;
using System.Text;
using System.Globalization;

public class HatType
{
    private int _x;
    private int _y;
    private float _z;
    private float _armor;
    private string _rarity;
    private bool _isForMasterBundle;
    
    public HatType(int x, int y, float z, float armor, string rarity, bool isForMasterBundle)
    {
        _x = x;
        _y = y;
        _z = z;
        _armor = armor;
        _rarity = rarity;
        _isForMasterBundle = isForMasterBundle;
    }
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Hat");
            writer.WriteLine("Rarity {0}", _rarity);
            writer.WriteLine("Useable Clothing");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", _x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", _y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", _z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Armor {0}", _armor.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
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