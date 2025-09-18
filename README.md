Introduction

While working with Unturned mods in Unity, I often needed to create a large number of folders for the game. To simplify this process, I wrote a Unity script that automates and speeds up folder creation and file copying.

How It Works

In your project folder, you’ll find a prefab named YourPrefabNameHere. Drag this prefab into your scene.

The script attached to the prefab has several fields that you’ll need to fill out.

You also need to enter the source folder (starting from the Assets folder) and the destination folder where everything should be copied.

To create your own configuration:

Right-click in the Project window.

Select Create → Scriptable Object.

Choose the configuration type that fits your needs.

Fill in the data for the Scriptable Object you created, including the source and destination folders.

Assign this Scriptable Object to the corresponding field in the script.

Press the Play button in the Unity Editor to run the script.

That’s it — the script will automatically create the necessary folders and copy files to the destination you specify.