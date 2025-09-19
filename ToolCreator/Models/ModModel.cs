public class ModModel
{
    public string FolderName;
    public string FolderPath;
    public ModeType Type;

    public ModModel(string folderName, string folderPath, ModeType type)
    {
        FolderName = folderName;
        FolderPath = folderPath;
        Type = type;
    }
}