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
        GenerateEnglishFileContent(Path.Combine(folderPath));
    }
    
    private void GenerateDataFileContent(string filePath)
    {
        switch (_modeType)
        {
            case ModeType.Supply:
                
                break;
            
            case ModeType.Barricade:
                
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
    
    private void GenerateEnglishFileContent(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("Name {0}");
            writer.WriteLine("Description {0}");
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
        Medical
    }
}
