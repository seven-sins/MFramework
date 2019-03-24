using System.IO;
using UnityEngine;

namespace MFramework
{
    public class AssetBundleExample 
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("MFramework/Example/24.AssetBundleExample/Build AssetBundle", false, 24)]
        static void MenuClicked()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }
            UnityEditor.BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath,UnityEditor.BuildAssetBundleOptions.None,UnityEditor.BuildTarget.StandaloneWindows);
        }
#endif
    }

}
