using System;
using UnityEngine;
using System.IO;
using System.Text;
using System.Globalization;

public class CreatorUntirendFolder : MonoBehaviour
{
    [Header("Folder path")]
    [SerializeField] private string _folderPath;
    [SerializeField] private string _targetFolderPath;
    
    [Header("ModeType")]
    [SerializeField] private ModeType _modeType;
    
    [Header("ModeName")]
    [SerializeField] private string _modeName;
    [SerializeField] private string _modeDescription;

    [Header("X, Y, Z Camera")]
    [SerializeField] private int _x;
    [SerializeField] private int _y;
    [SerializeField] private float _z;
    
    [Header("Barricades")]
    [SerializeField] private int _barricadeHealth;
    [SerializeField] private float _barricadeRange;
    [SerializeField] private float _barricadeRadius;
    [SerializeField] private float _barricadeOffset;
    [SerializeField] private float _barricadeExplosion;

    private const string ENGLISH_FILE_NAME = "English.dat";

    private void Awake()
    {
        if (string.IsNullOrEmpty(_targetFolderPath) || string.IsNullOrEmpty(_folderPath))
        {
            Debug.LogError("Folder name or target folder name is empty");
            return;
        }
        
        Debug.Log("All data is loaded");
    }

    private void Start()
    {
        string[] directories = Directory.GetDirectories(_folderPath);
        
        foreach (string directory in directories)
        {
            string folderName = Path.GetFileName(directory);
            
            CreateFolder(folderName);
            
            Debug.Log($"Folder: {folderName}");
        }
    }

    private void CreateFolder(string folderName)
    {
        string folderPath = Path.Combine(_targetFolderPath, folderName);
        Directory.CreateDirectory(folderPath);
        
        GenerateDataFileContent(Path.Combine(folderPath, folderName + ".dat"));
        GenerateEnglishFileContent(Path.Combine(folderPath, ENGLISH_FILE_NAME));
    }
    
    private void GenerateDataFileContent(string filePath)
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
            writer.WriteLine("Size_X {0}", _x.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Y {0}", _y.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Size_Z {0}", _z.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Health {0}", _barricadeHealth.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Range {0}", _barricadeRange.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Radius {0}", _barricadeRadius.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine("Offset {0}", _barricadeOffset.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Explosion {0}", _barricadeExplosion.ToString(CultureInfo.InvariantCulture));
            writer.WriteLine();
            writer.WriteLine("Has_Clip_Prefab false");
            writer.WriteLine();
            writer.WriteLine("Procedurally_Animate_Inertia false");
        }
        
        Debug.Log("Data File is created");
    }
    
    private void GenerateEnglishFileContent(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("Name {0}", _modeName);
            writer.WriteLine("Description {0}", _modeDescription);
        }
        
        Debug.Log("English File is created");
    }
    
    public enum ModeType
    {
        Barricade,
    }
}
