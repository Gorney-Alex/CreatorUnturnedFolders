using System;
using System.IO;
using System.Text;
using System.Globalization;

public class GasMaskType
{
    public void CreateDataFile(string filePath, int x, int y, float z, int width, float armor, int height)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Mask");
            writer.WriteLine("Rarity Common");
            writer.WriteLine("Useable Clothing");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Exclude_From_Master_Bundle");
        }
    }
}