using System;
using System.IO;
using System.Text;
using System.Globalization;

//Gorney-Alex program

public class MedicalType : ICanBeCreated
{
    private int _x;
    private int _y;
    private float _z;
    private int _health;
    private int _virus;
    private int _vision;
    private int _energy;
    private bool _isAid;
    private bool _isHealBleeding;
    private bool _isHealBones;
    private string _rarity;
    private bool _isForMasterBundle;
    
    public MedicalType(int x, int y, float z, int health, int virus, int vision, int energy, bool isAid, bool isHealBleeding, bool isHealBones, string rarity, bool isForMasterBundle)
    {
        _x = x;
        _y = y;
        _z = z;
        _health = health;
        _virus = virus;
        _vision = vision;
        _energy = energy;
        _isAid = isAid;
        _isHealBleeding = isHealBleeding;
        _isHealBones = isHealBones;
        _rarity = rarity;
        _isForMasterBundle = isForMasterBundle;
    }
    
    public void CreateDataFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Vest");
            writer.WriteLine("Rarity {0}", _rarity);
            writer.WriteLine("Useable Clothing");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", _x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", _y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", _z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            if (_health != 0) writer.WriteLine("Health {0}", _health);
            if (_virus != 0) writer.WriteLine("Virus {0}", _virus);
            if (_vision != 0) writer.WriteLine("Vision {0}", _vision);
            if (_energy != 0) writer.WriteLine("Energy {0}", _energy);
            if (_isAid) writer.WriteLine("Aid");
            if (_isHealBleeding) writer.WriteLine("Bleeding_Modifier Heal");
            if (_isHealBones) writer.WriteLine("Bones_Modifier Heal");
            writer.WriteLine();
            if (!_isForMasterBundle) writer.WriteLine("Exclude_From_Master_Bundle");
        }
    }
}