Hooks, when written for this patch, must include "CLHOOK" before the hook, and do not require a colon after 'CLHOOK' 
 Example 1: //CLHOOKGAMELOAD
 Example 2: /*CLHOOKANYSCENELOAD*/

Supported hooks, by default, are:
    "CLHOOKGAMELOAD"
    "CLHOOKANYSCENELOAD"
    "CLHOOKWORLDGENERATED"
    "CLHOOKDAY"
    "CLHOOKNIGHT"
    "CLHOOKINVENTORYOPEN"
    "CLHOOKINVENTORYCLOSE"
    "CLHOOKITEMCRAFTED"
    "CLHOOKDARTTHROWN"
    "CLHOOKDRONESPAWNED"
    "CLHOOKATEFOOD"
    "CLHOOKFURNITUREDESTROYED"
    "CLHOOKFURNITUREDAMAGED"
    "CLHOOKINTERACTEDWITHOBJECT"
    "CLHOOKILDONE"
    "CLHOOKUSEDLIGHTER"
    "CLHOOKMELEEATTACKED"
    "CLHOOKOBJECTDAMAGED"
    "CLHOOKOBJECTDESTROYED"
    "CLHOOKHUNGERTICK"
    "CLHOOKPLAYERDIED"
    "CLHOOKPLAYERDAMAGED"
    "CLHOOKOBTAINEDPOWERUP"
    "CLHOOKSTARTEDSLEEPING"
    "CLHOOKWOKEUP"
    "CLHOOKSPAWNEDSTAFF"
    "CLHOOKZOOMEDIN"
    "CLHOOKFINISHEDGEN"
    "CLHOOKGAMESAVED"
    "CLHOOKGAMEDELETED"

You can also delay hook triggers by simply putting "DEL" before the hook. Delayed hooks run 2 seconds after the hook is initially triggered. This delay is constant, so in order to run at a diferent delay you'll need to use a coroutine to halt it longer.
 Example: //DELCLHOOKGAMELOAD

You can also include .dlls by adding a "MODULE:" line. They MUST end with .dll, otherwise you'll cause a kernel panic.
 Example: //MODULE:Sirenix.Utilities.dll
 Example: /*MODULE:Sirenix.Utilities.dll*/


Modded items:

You may need, in addition to Unity 2019.1.10f1:
https://github.com/dnSpy/dnSpy/releases
https://sourceforge.net/projects/utinyripper/files/latest/download

Drop the "SCP-3008_Data" folder into the uTinyRipper window, then click export. It may take some time.

Download Unity 2019.1.10f1, which is available on the unity legacy version repository. Despite the minor version mismatch with the game's compiled version, it still works fine.
Create a new project with a memorable path, and once it's done, close the unity editor. Go into your uTinyRipper files and replace your project's Assets and ProjectSettings folders with the uTinyRipper ones. Reload the unity project.

You then need a script to compile AssetBundles. Copy the Editor folder, found next to this file, into the assets folder.

Importing meshes is very simple. In blender, export a model as a .fbx, making sure to enable the Copy path mode and clicking the box to the right. If done correctly, the model should contain all the materials that were included in your mesh.

After this, make a new ItemSO object. The name is very important, so ensure it is unique and identifiable. You will need to use the same name for recipies.

Depending on if your item is a placable object or a tool, you may need to make a "placer". Placers consist of an empty gameObject with the "Handheld Object Placer" script attached, and a prefab selected with the object you want to be able to place.
Then assign the FPItem variable of the ItemSO with your object, either the Placer or tool prefab. Make sure to set your ItemSO's properties properly.

//Look at line 78 for information on custom scripting

Create a new AssetBundle and give it an identifiable name, prefferably the same as your ItemSO. You need to include the ItemSO and prefabs in the AssetBundle. Once done, click on the "Assets" tab on the top right, and click "Build ABs".

Once it has finished compiling, copy the extensionless file with the same name (You don't need the 'Assets' or .manifest files) and paste it in the Plugins folder in Scripts\Mods\ItemLoader\.

Recipes can be made by writing a standard text document by the same name as your itemSO, with no extension. Use the name of the required resource, and then the number required, separated by '|' (the shift of '\')
Recipe files can also be read by using the LoadRecipeArray function in the MSHost class.

The "Overrides" folder allows you to modify recipies, modded or default. They work the same way as normal recipies otherwise.

If you're making complex systems whose scripts depend on eachother, It is recommended that you split each class into a new ClassesToCompile entry, and enable the Aggregate bool.  

Line 78: To add custom scripts to an item, add the ModdedScript component. Write code in the ClassesToCompile string array. It will be compiled before the Override files are loaded.
Added a MSTarget to the ItemSO.FPItem's gameObject IF the ModdedScript component is not on that object. ModdedScript strings are compiled directly to the gameObject the ModdedScript is on.


Configs can be created using the WriteFullConfig and WriteConfigLine methods, in the MSHost class. You can load config data either by making your own iterator and using the LoadConfig function, or using an interger with the LoadConfigLine function.
MSHost also contains FileExists and DirectoryExists functions.
These functions WILL NOT ALLOW the use of .. in their inputs

Cusotm Isles are made very simlarly to a normal modded object. The main difference is that they're placed in the SCP-3008_Data/StreamingAssets/AssetBundles/{NormalIsles, MiniIsles} folders. Which one depends on what isle type it is. It's best to experiment when it comes to proportions here.
Shouldn't be too difficult to get one working, as long as it's placed properly in both testing, that being the proper NormalIsles vs MiniIsles folders, and in export, that being in "StreamingAssets/AssetBundles/{NormalIsles, MiniIsles}"