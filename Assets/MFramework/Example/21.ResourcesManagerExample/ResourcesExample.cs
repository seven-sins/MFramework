﻿using System.Collections.Generic;
using UnityEngine;

namespace MFramework
{
    public class ResourcesExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("MFramework/Example/21.ResourcesExample", false, 21)]
#endif
        static void MenuClicked()
        {
            // UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("ResourcesManagerExample").AddComponent<ResourcesManagerExample>();
        }

        ResLoader resLoader = new ResLoader();

        void Start()
        {
            resLoader.LoadSync<AudioClip>("yu");
        }

        private void OnDestroy()
        {
            resLoader.ReleaseAsset();
        }
    }

}