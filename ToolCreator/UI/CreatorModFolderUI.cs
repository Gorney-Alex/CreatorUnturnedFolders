using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CreatorModFolderUI : EditorWindow
{
    private FolderGetter _folderGetter;
    private ModCreatorLogic _modCreatorLogic;
    
    private string _unityFolderPath = "";
    private string _targetFolderPath = "";

    private bool _showMods;
    private List<ModModel> _exportMods;
    private Vector2 _scrollPosition;
    private Vector2 _exportScrollPosition;
    
    [MenuItem("Tools/Mod Folder Creator")]
    public static void ShowWindow()
    {
        GetWindow<CreatorModFolderUI>("Mod Folder Creator");
    }

    private void OnEnable()
    {
        _folderGetter = new FolderGetter();
        _modCreatorLogic = new ModCreatorLogic();
        
        _exportMods = new List<ModModel>();
        
        _showMods = false;
    }

    public void OnGUI()
    {
        UnityFolderPathStep();
        TargetFolderPathStep();
        ModeContainerStep();
        CreateFoldersStep();
    }

    private void UnityFolderPathStep()
    {
        GUILayout.Label("Step 1. Choose Unity folder", EditorStyles.largeLabel);
        
        GUILayout.TextField("Now path: " + _unityFolderPath, EditorStyles.whiteLargeLabel);
        
        if (GUILayout.Button("Choose folder"))
        {
            string newPath = _folderGetter.GetFolderPath();
            if (!string.IsNullOrEmpty(newPath))
            {
                _unityFolderPath = newPath;
                _modCreatorLogic.SetUnityFolderPath(_unityFolderPath);
            }
        }
    }

    private void TargetFolderPathStep()
    {
        GUILayout.Label("Step 2. Choose Target folder", EditorStyles.largeLabel);
        
        GUILayout.TextField("Now path: " + _targetFolderPath, EditorStyles.whiteLargeLabel);
        
        if (GUILayout.Button("Choose folder"))
        {
            string newPath = _folderGetter.GetFolderPath();
            if (!string.IsNullOrEmpty(newPath))
            {
                _targetFolderPath = newPath;
                _modCreatorLogic.SetTargetFolderPath(_targetFolderPath);
            }
        }
    }

    private void ModeContainerStep()
    {
        GUILayout.Label("Step 3. Type mods", EditorStyles.largeLabel);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Take mods"))
        {
            _modCreatorLogic.Input();
            _showMods = !_showMods;
        }
        
        if (_showMods && _modCreatorLogic._mods.Count > 0)
        {
            if (GUILayout.Button("Save Changes for Export"))
            {
                SaveToExportList();
            }
        }
        GUILayout.EndHorizontal();
        
        if (_showMods && _modCreatorLogic._mods.Count > 0)
        {
            GUILayout.Space(10);
            GUILayout.Label($"Found mods ({_modCreatorLogic._mods.Count}):", EditorStyles.boldLabel);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Folder Name", EditorStyles.boldLabel, GUILayout.ExpandWidth(true));
            GUILayout.Label("Type", EditorStyles.boldLabel, GUILayout.Width(120));
            GUILayout.EndHorizontal();
            
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Height(150));
            
            for (int i = 0; i < _modCreatorLogic._mods.Count; i++)
            {
                ModModel currentMod = _modCreatorLogic.GetCurrentMod(i);
                
                GUILayout.BeginHorizontal();
                currentMod.FolderName = GUILayout.TextField(currentMod.FolderName, GUILayout.ExpandWidth(true));
                currentMod.Type = (ModeType)EditorGUILayout.EnumPopup(currentMod.Type, GUILayout.Width(120));
                GUILayout.EndHorizontal();
            }
            
            GUILayout.EndScrollView();
        }
        
        ShowExportList();
    }
    
    private void SaveToExportList()
    {
        _exportMods.Clear();
        
        foreach (ModModel mod in _modCreatorLogic._mods)
        {
            ModModel exportMod = new ModModel(mod.FolderName, mod.FolderPath, mod.Type);
            _exportMods.Add(exportMod);
        }
        
        Debug.Log($"Saved {_exportMods.Count} mods for export");
    }
    
    private void ShowExportList()
    {
        if (_exportMods.Count > 0)
        {
            GUILayout.Space(20);
            GUILayout.Label($"Export List ({_exportMods.Count} mods):", EditorStyles.largeLabel);
            
            _exportScrollPosition = GUILayout.BeginScrollView(_exportScrollPosition, GUILayout.Height(100));
            
            for (int i = 0; i < _exportMods.Count; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label($"{i + 1}.", GUILayout.Width(25));
                GUILayout.Label(_exportMods[i].FolderName, GUILayout.ExpandWidth(true));
                GUILayout.Label(_exportMods[i].Type.ToString(), GUILayout.Width(120));
                
                if (GUILayout.Button("Remove", GUILayout.Width(60)))
                {
                    _exportMods.RemoveAt(i);
                    break;
                }
                GUILayout.EndHorizontal();
            }
            
            GUILayout.EndScrollView();
            
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Clear Export List"))
            {
                _exportMods.Clear();
            }
            GUILayout.FlexibleSpace();
            GUILayout.Label($"Ready for export: {_exportMods.Count} mods", EditorStyles.miniLabel);
            GUILayout.EndHorizontal();
        }
    }

    private void CreateFoldersStep()
    {
        GUILayout.Label("Step 4. Create mod folders", EditorStyles.largeLabel);
        
        if (GUILayout.Button("Create folders"))
        {
            _modCreatorLogic.CreateModFolders(_exportMods);
        }
    }
}