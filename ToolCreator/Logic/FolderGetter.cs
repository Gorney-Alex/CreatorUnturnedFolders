using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

//Gorney-Alex program

public class FolderGetter : EditorWindow
{
    public string GetFolderPath()
    {
        string folderPath = EditorUtility.OpenFolderPanel("Choose folder", "Assets", "");
        if (!string.IsNullOrEmpty(folderPath))
        {
            if (folderPath.StartsWith(Application.dataPath))
            {
                folderPath = "Assets" + folderPath.Substring(Application.dataPath.Length);
            }
        }
        
        return folderPath;
    }
}
