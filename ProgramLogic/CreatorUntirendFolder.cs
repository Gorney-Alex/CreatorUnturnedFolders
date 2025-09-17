using UnityEngine;
using System.IO;
using System.Text;

public class CreatorUntirendFolder : MonoBehaviour
{
    [Header("Folder path")]
    [SerializeField] private string _folderPath;
    [SerializeField] private string _targetFolderPath;
    
    [Header("ModeType")]
    [SerializeField] private ModeType _modeType;
    
    [Header("Optional part")]
    [SerializeField] private bool _isForMasterBundle;
    
    BarricadeType _barricadeType;
    HatType _hatType;
    PantsType _pantsType;
    ShirtType _shirtType;
    VestType _vestType;
    SupplyType _supplyType;
    MedicalType _medicalType;
    MaskType _maskType;
    FoodType _foodType;
    WaterType _waterType;
    CloudType _cloudType;
    BackPackType _backPackType;
    
    [Header("Configs")]
    [SerializeField] private BarricadeConfig _barricadeConfig;
    [SerializeField] private BackPackConfig _backPackConfig;
    [SerializeField] private HatConfig _hatConfig;
    [SerializeField] private PantConfig _pantsConfig;
    [SerializeField] private ShirtConfig _shirtConfig;
    [SerializeField] private VestConfig _vestConfig;
    [SerializeField] private SupplyConfig _supplyConfig;
    [SerializeField] private EdibleConfig _foodConfig;
    [SerializeField] private EdibleConfig _waterConfig;
    [SerializeField] private CloudConfig _cloudConfig;
    [SerializeField] private MedicalConfig _medicalConfig;
    [SerializeField] private MaskConfig _maskConfig;
    

    private void Awake()
    {
        if (string.IsNullOrEmpty(_targetFolderPath) || string.IsNullOrEmpty(_folderPath))
        {
            Debug.LogError("Folder name or target folder name is empty");
            return;
        }
        
        Debug.Log("Start to create");
    }

    private void Start()
    {
        Input();
    }
    
    private void Input()
    {
        switch (_modeType)
        {
            case ModeType.Supply:
                _supplyType = new SupplyType(_shirtConfig.X, _shirtConfig.Y, _shirtConfig.Z, _shirtConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_supplyType, _shirtConfig);
                break;
            
            case ModeType.Barricade: 
                _barricadeType = new BarricadeType(_barricadeConfig.X, _barricadeConfig.Y, _barricadeConfig.Z, _barricadeConfig.Health, _barricadeConfig.Range, _barricadeConfig.Radius, _barricadeConfig.Offset, _barricadeConfig.Explosion, _barricadeConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_barricadeType, _barricadeConfig);
                break;
            
            case ModeType.Cloud:
                _cloudType = new CloudType(_cloudConfig.X, _cloudConfig.Y, _cloudConfig.Z, _cloudConfig.Gravity, _cloudConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_cloudType, _cloudConfig);
                break;
            
            case ModeType.Food: 
                _foodType = new FoodType(_foodConfig.X, _foodConfig.Y, _foodConfig.Z, _foodConfig.Health, _foodConfig.Food, _foodConfig.Water, _foodConfig.Virus, _foodConfig.Vision, _foodConfig.Energy, _foodConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_foodType, _foodConfig);
                break;
            
            case ModeType.Hat:
                _hatType = new HatType(_hatConfig.X, _hatConfig.Y, _hatConfig.Z, _hatConfig.Armor, _hatConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_hatType, _hatConfig);
                break;
            
            case ModeType.Vest:
                _vestType = new VestType(_vestConfig.X, _vestConfig.Y, _vestConfig.Z, _vestConfig.Width, _vestConfig.Armor, _vestConfig.Height, _vestConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_vestType, _vestConfig);
                break;
            
            case ModeType.Mask:
                _maskType = new MaskType(_maskConfig.X, _maskConfig.Y, _maskConfig.Z, _maskConfig.Rarity.ToString(), _maskConfig.IsProofRadiation, _isForMasterBundle);
                CreateFolderWithDataFiles(_maskType, _maskConfig);
                break;
            
            case ModeType.Pants:
                _pantsType = new PantsType(_pantsConfig.X, _pantsConfig.Y, _pantsConfig.Z, _pantsConfig.Width, _pantsConfig.Armor, _pantsConfig.Height, _pantsConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_pantsType, _pantsConfig);
                break;
            
            case ModeType.Shirt:
                _shirtType = new ShirtType(_shirtConfig.X, _shirtConfig.Y, _shirtConfig.Z, _shirtConfig.Width, _shirtConfig.Armor, _shirtConfig.Height, _shirtConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_shirtType, _shirtConfig);
                break;
            
            case ModeType.Water:
                _waterType = new WaterType(_waterConfig.X, _waterConfig.Y, _waterConfig.Z, _waterConfig.Health, _waterConfig.Food, _waterConfig.Water, _waterConfig.Virus, _waterConfig.Vision, _waterConfig.Energy, _waterConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_waterType, _waterConfig);
                break;
            
            case ModeType.Medical:
                _medicalType = new MedicalType(_medicalConfig.X, _medicalConfig.Y, _medicalConfig.Z, _medicalConfig.Health, _medicalConfig.Virus, _medicalConfig.Vision, _medicalConfig.Energy, _medicalConfig.IsAid, _medicalConfig.IsHealBleeding, _medicalConfig.IsHealBones, _medicalConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_medicalType, _medicalConfig);
                break;
            
            case ModeType.Backpack:
                _backPackType = new BackPackType(_backPackConfig.X, _backPackConfig.Y, _backPackConfig.Z, _backPackConfig.Width, _backPackConfig.Height, _backPackConfig.Rarity.ToString(), _isForMasterBundle);
                CreateFolderWithDataFiles(_backPackType, _backPackConfig);
                break;
        }
        
        Debug.Log("Data File is created");
    }

    private void CreateFolderWithDataFiles(ICanBeCreated creator, ItemConfig config)
    {
        string[] directories = Directory.GetDirectories(_folderPath);
        
        foreach (string directory in directories)
        {
            string folderName = Path.GetFileName(directory);
            CreateFolderWithDataFiles(folderName, creator, config);
            
            Debug.Log($"Folder: {folderName}");
        }
    }
    
    private void CreateFolderWithDataFiles(string folderName, ICanBeCreated creator, ItemConfig config)
    {
        string folderPath = Path.Combine(_targetFolderPath, folderName);
        Directory.CreateDirectory(folderPath);
        
        string mainDatPath = Path.Combine(folderPath, folderName + ".dat");
        creator.CreateDataFile(mainDatPath);
        
        string englishFilePath = Path.Combine(folderPath, "English.dat");
        GenerateEnglishFileContent(englishFilePath, config);
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
        Medical,
        Backpack
    }
}
