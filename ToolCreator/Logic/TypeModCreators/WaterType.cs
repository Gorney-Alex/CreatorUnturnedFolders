using System;
using System.IO;
using System.Text;
using System.Globalization;

//Gorney-Alex program

public class WaterType : ICanBeCreated
{
    private int _x;
    private int _y;
    private float _z;
    private int _health;
    private int _food;
    private int _water;
    private int _virus;
    private int _vision;
    private int _energy;
    private string _rarity;
    private bool _isForMasterBundle;
    
    public WaterType(int x, int y, float z, int health, int food, int water, int virus, int vision, int energy, string rarity, bool isForMasterBundle)
    {
        _x = x;
        _y = y;
        _z = z;
        _health = health;
        _food = food;
        _water = water;
        _virus = virus;
        _vision = vision;
        _energy = energy;
        _rarity = rarity;
        _isForMasterBundle = isForMasterBundle;
    }
    
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Water");
            writer.WriteLine("Rarity {0}", _rarity);
            writer.WriteLine("Useable Consumeable");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", _x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", _y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", _z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            if (_health != 0) writer.WriteLine("Health {0}", _health);
            if (_food != 0) writer.WriteLine("Food {0}", _food);
            if (_water != 0) writer.WriteLine("Water {0}", _water);
            if (_virus != 0) writer.WriteLine("Virus {0}", _virus);
            if (_vision != 0) writer.WriteLine("Vision {0}", _vision);
            if (_energy != 0) writer.WriteLine("Energy {0}", _energy);
            writer.WriteLine();
            if (!_isForMasterBundle) writer.WriteLine("Exclude_From_Master_Bundle");
        }
    }
}