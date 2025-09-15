using System;
using System.IO;
using System.Text;
using System.Globalization;

public class VestType
{
    public void CreateDataFile(string filePath, int x, int y, float z, int width, float armor, int height)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Vest");
            writer.WriteLine("Rarity Common");
            writer.WriteLine("Useable Clothing");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Armor {0}", armor.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Width {0}", width.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Height {0}", height.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Exclude_From_Master_Bundle");
        }
    }
}