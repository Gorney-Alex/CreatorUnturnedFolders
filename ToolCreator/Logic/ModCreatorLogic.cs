using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ModCreatorLogic
{
    private string _unityFolderPath;
    private string _targetFolderPath;
    
    public List<ModModel> _mods;

    public ModCreatorLogic()
    {
        _unityFolderPath = "";
        _targetFolderPath = "";
        
        _mods = new List<ModModel>();
    }
    
    public void SetUnityFolderPath(string path) => _unityFolderPath = path;
    public void SetTargetFolderPath(string path) => _targetFolderPath = path;

    public void Input()
    {
        _mods.Clear();
        
        string[] directories = Directory.GetDirectories(_unityFolderPath);
        
        foreach (string directory in directories)
        {
            string folderName = Path.GetFileName(directory);
            ModeType currentType = DetectModeType(directory);
            string folderPath = Path.Combine(_targetFolderPath, folderName);
            
            ModModel newMod = new ModModel(folderName, folderPath, currentType);
            _mods.Add(newMod);
        }
    }

    public ModModel GetCurrentMod(int index)
    {
        return _mods[index];
    }
    
    public void CreateModFolders(List<ModModel> modsToCreate)
    {
        if (string.IsNullOrEmpty(_targetFolderPath))
        {
            Debug.LogError("Target folder path is not set!");
            return;
        }
        
        foreach (ModModel mod in modsToCreate)
        {
            CreateModByType(mod);
        }
        
        Debug.Log($"Successfully created {modsToCreate.Count} mod folders");
    }
    
    private void CreateModByType(ModModel mod)
    {
        ICanBeCreated creator = GetCreatorByType(mod.Type);
        
        if (creator != null)
        {
            CreateFolderWithDataFiles(creator, mod.FolderName);
            Debug.Log($"Created mod folder: {mod.FolderName} ({mod.Type})");
        }
    }
    
    private ICanBeCreated GetCreatorByType(ModeType type)
    {
        switch (type)
        {
            case ModeType.Supply:
                return new SupplyType();
            case ModeType.Barricade:
                return new BarricadeType();
            case ModeType.Pants:
                return new PantsType();
            case ModeType.Shirt:
                return new SupplyType();
            case ModeType.Vest:
                return new VestType();
            case ModeType.Backpack:
                return new BackPackType();
            case ModeType.Mask:
                return new MaskType();
            case ModeType.Hat:
                return new HatType();
            case ModeType.Water:
                return new WaterType();
            case ModeType.Food:
                return new FoodType();
            case ModeType.Unknown:
            default:
                return null;
        }
    }
    
    private void CreateFolderWithDataFiles(ICanBeCreated creator, string folderName)
    {
        string folderPath = Path.Combine(_targetFolderPath, folderName);
        Directory.CreateDirectory(folderPath);
        
        string mainDatPath = Path.Combine(folderPath, folderName + ".dat");
        creator.CreateDataFile(mainDatPath);
        
        string englishFilePath = Path.Combine(folderPath, "English.dat");
        GenerateEnglishFileContent(englishFilePath);
    }
    
    private void GenerateEnglishFileContent(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("Name");
            writer.WriteLine("Description");
        }
        
        Debug.Log("English File is created");
    }
    
    private ModeType DetectModeType(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

        bool hasItem = false;
        bool hasBarricade = false;
        bool hasVest = false;
        bool hasPants = false;
        bool hasShirt = false;
        bool hasHat = false;
        bool hasBackpack = false;
        bool HasMask = false;
        bool HasWater = false;

        foreach (string file in files)
        {
            string name = Path.GetFileNameWithoutExtension(file);

            if (name.Equals("Item", System.StringComparison.OrdinalIgnoreCase))
                hasItem = true;

            if (name.Equals("Barricade", System.StringComparison.OrdinalIgnoreCase))
                hasBarricade = true;

            if (name.Equals("Pants", System.StringComparison.OrdinalIgnoreCase))
                hasPants = true;
            
            if (name.Equals("Shirt", System.StringComparison.OrdinalIgnoreCase))
                hasShirt = true;
            
            if (name.Equals("Hat", System.StringComparison.OrdinalIgnoreCase))
                hasHat = true;
            
            if (name.Equals("Backpack", System.StringComparison.OrdinalIgnoreCase))
                hasBackpack = true;
            
            if (name.Equals("Mask", System.StringComparison.OrdinalIgnoreCase))
                HasMask = true;
            
            if (name.Equals("Vest", System.StringComparison.OrdinalIgnoreCase))
                hasVest = true;
            
            if (name.Equals("Use", System.StringComparison.OrdinalIgnoreCase))
                HasWater = true;
        }
        
        if (hasItem && hasBarricade) return ModeType.Barricade;
        if (hasItem && hasPants) return ModeType.Pants;
        if (hasItem && hasShirt) return ModeType.Shirt;
        if (hasItem && hasVest) return ModeType.Vest;
        if (hasItem && hasHat) return ModeType.Hat;
        if (hasItem && HasWater) return ModeType.Water;
        if (hasItem && hasBackpack) return ModeType.Backpack;
        if (hasItem && HasMask) return ModeType.Mask;
        if (hasItem) return ModeType.Supply;

        return ModeType.Unknown;
    }
}
