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
    
    BarricadeType _barricadeType;
    GasMaskType _gasMaskType;
    HatType _hatType;
    PantsType _pantType;
    ShirtType _shirtType;
    VestType _vestType;
    
    [SerializeField] private BarricadeConfig _barricadeConfig;
    [SerializeField] private ItemConfig _backPackConfig;
    [SerializeField] private HatConfig _hatConfig;
    [SerializeField] private PantConfig _pantConfig;
    [SerializeField] private ShirtConfig _shirtConfig;
    [SerializeField] private VestConfig _vestConfig;
    [SerializeField] private ItemConfig _supplyConfig;
    [SerializeField] private ItemConfig _foodConfig;
    [SerializeField] private ItemConfig _waterConfig;
    [SerializeField] private ItemConfig _cloudConfig;
    [SerializeField] private ItemConfig _medicalConfig;
    [SerializeField] private ItemConfig _maskConfig;
    

    private void Awake()
    {
        if (string.IsNullOrEmpty(_targetFolderPath) || string.IsNullOrEmpty(_folderPath))
        {
            Debug.LogError("Folder name or target folder name is empty");
            return;
        }

        InitializeObjects();
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
    
    private void GenerateDataFileContent(string filePath)
    {
        switch (_modeType)
        {
            case ModeType.Supply:
                
                break;
            
            case ModeType.Barricade: 
                _barricadeType.CreateDataFile(filePath);
                break;
            
            case ModeType.Cloud:
                
                break;
            
            case ModeType.Food:
                
                break;
            
            case ModeType.Hat:
                
                break;
            
            case ModeType.Vest:
                
                break;
            
            case ModeType.Mask:
                
                break;
            
            case ModeType.Pants:
                
                break;
            
            case ModeType.Shirt:
                
                break;
            
            case ModeType.Water:
                
                break;
            
            case ModeType.Medical:
                
                break;
        }
        
        Debug.Log("Data File is created");
    }
    
    private void CreateFolder(string folderName)
    {
        string folderPath = Path.Combine(_targetFolderPath, folderName);
        Directory.CreateDirectory(folderPath);
        
        GenerateDataFileContent(Path.Combine(folderPath, folderName + ".dat"));
    }
    
    private void GenerateEnglishFileContent(string filePath, ItemConfig config)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("Name {0}", config.ModeName);
            writer.WriteLine("Description {0}", config.ModeDescription);
        }
        
        Debug.Log("English File is created");
    }

    private void InitializeObjects()
    {
        _barricadeType = new BarricadeType(_barricadeConfig.X, _barricadeConfig.Y, _barricadeConfig.Z, _barricadeConfig.Health, _barricadeConfig.Range, _barricadeConfig.Radius, _barricadeConfig.Offset, _barricadeConfig.Explosion, _barricadeConfig.Rarity.ToString(), _barricadeConfig.IsForMasterBundle);
        _hatType = new HatType(_hatConfig.X, _hatConfig.Y, _hatConfig.Z, _hatConfig.Armor, _hatConfig.Rarity.ToString(), _hatConfig.IsForMasterBundle);
        _pantType = new PantsType(_pantConfig.X, _pantConfig.Y, _pantConfig.Z, _pantConfig.Width, _pantConfig.Armor, _pantConfig.Height, _pantConfig.Rarity.ToString(), _pantConfig.IsForMasterBundle);
        _shirtType = new ShirtType(_pantConfig.X, _pantConfig.Y, _pantConfig.Z, _pantConfig.Width, _pantConfig.Armor, _pantConfig.Height, _pantConfig.Rarity.ToString(), _pantConfig.IsForMasterBundle);
        _vestType = new VestType(_pantConfig.X, _pantConfig.Y, _pantConfig.Z, _pantConfig.Width, _pantConfig.Armor, _pantConfig.Height, _pantConfig.Rarity.ToString(), _pantConfig.IsForMasterBundle);
        
        Debug.Log("All data is loaded");
    }
    
    public enum ModeType
    {
        Barricade,
        Pants,
        Shirt,
        Vest,
        Hat,
        Mask,
        Supply,
        Food,
        Water,
        Cloud,
        Medical
    }
}
