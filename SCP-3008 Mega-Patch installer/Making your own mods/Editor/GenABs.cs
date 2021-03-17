using UnityEditor;
using System.IO;
public class GenABs
{
    [MenuItem("Assets/Build ABs")]
    static void BuildAllAssetBundles() =>   BuildPipeline.BuildAssetBundles("Assets", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
}