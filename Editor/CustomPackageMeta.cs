using UnityEditor;

public class CustomPackageMeta : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            if (str.EndsWith(".cs"))
            {
                AssetImporter assetImporter = AssetImporter.GetAtPath(str);
                assetImporter.SaveAndReimport();
            }
        }
    }
}
