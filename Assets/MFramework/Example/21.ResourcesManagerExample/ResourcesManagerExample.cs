using System.Collections.Generic;
using UnityEngine;

namespace MFramework
{
    public class ResourcesManagerExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("MFramework/Example/21.ResourcesManagerExample", false, 21)]
#endif
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("ResourcesManagerExample").AddComponent<ResourcesManagerExample>();
        }

        ResourceLoader resLoader = new ResourceLoader();

        void Start()
        {
            resLoader.LoadAsset<AudioClip>("yu");
        }

        private void OnDestroy()
        {
            resLoader.ReleaseAsset();
        }
    }

}
