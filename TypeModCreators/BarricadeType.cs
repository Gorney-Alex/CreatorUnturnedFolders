using System;
using System.IO;
using System.Text;
using System.Globalization;

public class BarricadeType
{
    public void CreateDataFile(string filePath, int x, int y, float z, int health, float range, float radius, float offset, int explosion)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("GUID {0}", Guid.NewGuid().ToString("N"));
            writer.WriteLine();
            writer.WriteLine("Type Barricade");
            writer.WriteLine("Rarity Rare");
            writer.WriteLine("Useable Barricade");
            writer.WriteLine("Build Campfire");
            writer.WriteLine("ID ");
            writer.WriteLine();
            writer.WriteLine("Size_X {0}", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Health {0}", health.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Range {0}", range.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Radius {0}", radius.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Offset {0}", offset.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Explosion {0}", explosion.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Has_Clip_Prefab false");
            writer.WriteLine();
            writer.WriteLine("Procedurally_Animate_Inertia false");
        }
    }
}
